using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CurrencyConverter4.Models
{
    public class Converter
    {
        public double OriginalAmount { get; set; }
        public IEnumerable<SelectListItem> OriginalName { get; set; }
        public IEnumerable<SelectListItem> TargetName { get; set; }
    }
}
