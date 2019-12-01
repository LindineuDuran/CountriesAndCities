using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountriesAndCities.Models
{
    public class CountryAndCity
    {
        public int ID { get; set; }
        public int CityID { get; set; }
        public string CountryID { get; set; }

        public virtual Country Country { get; set; }
        public virtual City City { get; set; }
    }
}