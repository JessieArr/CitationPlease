﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitationPlease.Models.GovInfo
{
    public class BillPackageSummary : PackageSummary
    {
        public string billType { get; set; }
        public string billNumber { get; set; }
    }
}
