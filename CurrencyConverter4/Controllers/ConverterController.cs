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
            Converter.OriginalName = Items;
            Converter.TargetName = Items;
            return View(Converter);
        }
        [HttpPost]
        public ActionResult Convert(double OriginalAmount, string OriginalName, string TargetName)
        {
            FreeConverter FreeConverter = new FreeConverter(CurrencyList);
            if(double.IsNaN(OriginalAmount))
            {
                Console.WriteLine(OriginalAmount + " is not a number");
                ModelState.AddModelError("OriginalAmount", "You must enter a number.");
            }
            else if(OriginalAmount < 0)
            {
                ModelState.AddModelError("OriginalAmount", "You must enter a positive number.");
            }
            else
            {
				double TargetAmount = FreeConverter.Convert(TargetName, OriginalName, OriginalAmount);
				StringBuilder Result = new StringBuilder();
				Result.Append(OriginalAmount + " " + OriginalName + " = " + TargetAmount + " " + TargetName);
				
				TempData["ConversionResult"] = Result.ToString();            
            }
            return RedirectToAction("Index");
        }
    }
}
