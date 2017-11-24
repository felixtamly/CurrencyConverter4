using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CurrencyConverter4.Models
{
    public class Converter
    {
        public double OriginalAmount { get; set; }

        public string OriginalCurrencyName { get; set; }
        public IEnumerable<SelectListItem> OriginalCurrency { get; set; }

        public string TargetCurrencyName { get; set; }
        public IEnumerable<SelectListItem> TargetCurrency { get; set; }
    }
}
