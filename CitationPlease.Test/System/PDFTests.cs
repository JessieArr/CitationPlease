using CitationPlease.Helpers;
using CitationPlease.Services;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Content;
using PdfSharp.Pdf.Content.Objects;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static PdfSharp.Pdf.PdfDictionary;

namespace CitationPlease.Test.System
{
    public class PDFTests
    {
        [Fact]
        public async Task Test()
        {
            var client = new GovInfoClient(new SecretHelper());
            var pdf = await client.DownloadPDF("https://www.govinfo.gov/content/pkg/USCOURTS-cand-4_17-cv-04405/pdf/USCOURTS-cand-4_17-cv-04405-9.pdf");
            var x = PdfReader.Open(pdf);
            var fullBillText = "";
            foreach(var page in x.Pages)
            {
                var contents = ExtractText(page);
                foreach(var content in contents)
                {
                    fullBillText += content + Environment.NewLine;
                }
            }
        }

        public IEnumerable<string> ExtractText(PdfPage page)
        {
            var content = ContentReader.ReadContent(page);
            var text = GetTextFromCObject(content);
            return text;
        }

        public List<string> GetTextFromCObject(CObject cObject)
        {
            var result = new List<string>();
            if (cObject is COperator)
            {
                var cOperator = cObject as COperator;
                if (cOperator.OpCode.Name == OpCodeName.Tj.ToString() ||
                    cOperator.OpCode.Name == OpCodeName.TJ.ToString())
                {
                    foreach (var cOperand in cOperator.Operands)
                    {
                        result.AddRange(GetTextFromCObject(cOperand));
                    }
                }
            }
            else if (cObject is CSequence)
            {
                var cSequence = cObject as CSequence;
                var sequenceText = "";
                foreach (var element in cSequence)
                {
                    var textInSequence = GetTextFromCObject(element);
                    foreach(var text in textInSequence)
                    {
                        sequenceText += text;
                    }
                }
                result.Add(sequenceText + Environment.NewLine);
            }
            else if (cObject is CString)
            {
                var cString = cObject as CString;
                result.Add(cString.Value);
            }
            return result;
        }

        public IEnumerable<string> ExtractTextFromObject(CObject cObject)
        {
            if (cObject is COperator)
            {
                var cOperator = cObject as COperator;
                if (cOperator.OpCode.Name == OpCodeName.Tj.ToString() ||
                    cOperator.OpCode.Name == OpCodeName.TJ.ToString())
                {
                    foreach (var cOperand in cOperator.Operands)
                        foreach (var txt in ExtractTextFromObject(cOperand))
                            yield return txt;
                }
            }
            else if (cObject is CSequence)
            {
                var cSequence = cObject as CSequence;
                foreach (var element in cSequence)
                    foreach (var txt in ExtractTextFromObject(element))
                        yield return txt;
            }
            else if (cObject is CString)
            {
                var cString = cObject as CString;
                yield return cString.Value;
            }
        }
    }
}
