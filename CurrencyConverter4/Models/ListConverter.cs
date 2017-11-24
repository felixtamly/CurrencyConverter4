﻿using System;
using System.Collections.Generic;

namespace CurrencyConverter4.Models
{
    public class ListConverter
    {
        readonly List<Currency> CurrencyList;
        public ListConverter(List<Currency> CurrencyList)
        {
            this.CurrencyList = CurrencyList;
        }
        public List<Currency> Convert(string TargetName)
        {
            FreeConverter FreeConverter = new FreeConverter(CurrencyList);
            List<Currency> ConvertedList = new List<Currency>();
            foreach (Currency Currency in CurrencyList)
            {
                double NewRate = 1 / (FreeConverter.Convert(TargetName, Currency.Name, 1));
                ConvertedList.Add(new Currency(Currency.Name, Math.Round(NewRate, 4)));
            }
            return ConvertedList;
        }
    }
}
