using EntityFramework.Seeder;

namespace SeedingDataFromCSV.Migrations
{
    using CsvHelper;
    using SeedingDataFromCSV.Domain;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<SeedingDataFromCSV.Domain.LocationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LocationContext context)
        {
            context.Countries.SeedFromResource("SeedingDataFromCSV.Domain.SeedData.countries.csv", c => c.Code);
            context.SaveChanges();
            context.ProvinceStates.SeedFromResource("SeedingDataFromCSV.Domain.SeedData.provincestates.csv", p => p.Code,
                new CsvColumnMapping<ProvinceState>("CountryCode", (state, countryCode) =>
                {
                    state.Country = context.Countries.Single(c => c.Code == countryCode);
                })
             );            
        }
    }
}
