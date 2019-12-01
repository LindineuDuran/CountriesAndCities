using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountriesAndCities.Models
{
    public enum Continent
    {
        Asia, Europe, NorthAmerica, Africa, Oceania, Antarctica, SouthAmerica
    }

    public class Country
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public Continent? Continent { get; set; }
        public string Region { get; set; }
        public double SurfaceArea { get; set; }
        public int IndepYear { get; set; }
        public int Population { get; set; }
        public double LifeExpectancy { get; set; }
        public double GNP { get; set; }
        public double GNPOld { get; set; }
        public string LocalName { get; set; }
        public string GovernmentForm { get; set; }
        public string HeadOfState { get; set; }
        public int Capital { get; set; }
        public string Code2 { get; set; }
        public virtual ICollection<CountryAndCity> CountryAndCity { get; set; }
    }
}