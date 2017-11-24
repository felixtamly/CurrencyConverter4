using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CurrencyConverter4.Models
{
    public class ReverseConverter
    {
        public double TargetAmount { get; set; }
		
		public string TargetCurrencyName { get; set; }
		public IEnumerable<SelectListItem> TargetCurrency { get; set; }

        public string OriginalCurrencyName { get; set; }
        public IEnumerable<SelectListItem> OriginalCurrency { get; set; }

    }
}
