using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CurrencyConverter4.Models;

namespace CurrencyConverter4.Controllers
{
    public class CurrenciesController : Controller
    {
        static XmlToCurrencyListConverter XmlConverter = new XmlToCurrencyListConverter();
        static List<Currency> CurrencyList = XmlConverter.GetCurrencyList();

        public ActionResult Index()
        {
            if(TempData["NewList"] != null)
            {
                ViewData["NewRate"] = TempData["Rate"];
                return View((TempData["NewList"])); 
            }
            else
            {
                ViewData["NewRate"] = "EUR";
				return View (CurrencyList);
            }
        }
        public ActionResult GetNewList(string Name)
        {
            ListConverter ListConverter = new ListConverter(CurrencyList);
            List<Currency> NewCurrencyList = new List<Currency>();
            NewCurrencyList = ListConverter.Convert(Name);
            TempData["NewList"] = NewCurrencyList;
            TempData["Rate"] = Name.ToUpper();
            return RedirectToAction("Index", "Currencies");
        }
    }
}
