﻿using System.Collections.Generic;

namespace Com.Jcvegan.CountriesApp.Models
{
    public class CountryFullModel
    {
        public string Name { get; set; }
        public string[] TopLevelDomain { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public string[] CallingCodes { get; set; }
        public string Capital { get; set; }
        public string[] AltSpellings { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public long? Population { get; set; }
        public float[] LatLng { get; set; }
        public string Demonym { get; set; }
        public decimal? Area { get; set; }
        public string Gini { get; set; }
        public string[] TimeZones { get; set; }
        public string[] Borders { get; set; }
        public string NativeName { get; set; }
        public string NumericCode { get; set; }
        public CurrencyModel[] Currencies { get; set; }
        public LanguageModel[] Languages { get; set; }
        public IDictionary<string,string> Translations { get; set; }
        public string Flag { get; set; }
        public RegionModel[] RegionalBlocs { get; set; }
        public string Cioc { get; set; }
    }
}