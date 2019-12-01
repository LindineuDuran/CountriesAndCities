using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using CountriesAndCities.Models;

namespace CountriesAndCities.DAL
{
    public class CountryAndCityContext : DbContext
    {
        public CountryAndCityContext() : base("CountryAndCityContext") { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryAndCity> CountriesAndCities { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}