﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaafiMobile.Core.Model
{
    public class Currency
    {
        public string CurrencyName { get; set; }

        public string CurrencySymbol { get; set; }

        public int CurrencyId { get; set; }

        public override string ToString()
        {
            return $"{CurrencyName} ({CurrencySymbol})";
        }
    }
}
