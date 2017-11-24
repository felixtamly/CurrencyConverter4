using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CurrencyConverter4.Models;

namespace CurrencyConverter4.Controllers
{
    public class ConverterController : Controller
    {
        static XmlToCurrencyListConverter XmlConverter = new XmlToCurrencyListConverter();
        static List<Currency> CurrencyList = XmlConverter.GetCurrencyList();
        public ActionResult Index()
        {
            Converter Converter = new Converter();
            List<SelectListItem> Items = new List<SelectListItem>();
            foreach (Currency Currency in CurrencyList)
            {
                Items.Add(new SelectListItem { Text = Currency.Name, Value = Currency.Name });
            }
            Converter.OriginalCurrency = Items;
            Converter.TargetCurrency = Items;
            return View(Converter);
        }
        [HttpPost]
        public ActionResult Convert(Converter Converter)
        {
            FreeConverter FreeConverter = new FreeConverter(CurrencyList);
            if(Converter.OriginalAmount < 0.0)
            {
                Converter.OriginalAmount = 0.0;
            }
            double TargetAmount = FreeConverter.Convert(Converter.TargetCurrencyName, Converter.OriginalCurrencyName, Converter.OriginalAmount);
            StringBuilder Result = new StringBuilder();
            Result.Append(Converter.OriginalAmount + " " + Converter.OriginalCurrencyName + " = " + String.Format("{0:.##}", TargetAmount) + " " + Converter.TargetCurrencyName);
            TempData["ConversionResult"] = Result.ToString();            
            return RedirectToAction("Index");
        }
    }
}
