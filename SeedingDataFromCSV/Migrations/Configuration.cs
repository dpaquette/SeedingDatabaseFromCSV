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
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "SeedingDataFromCSV.Domain.SeedData.countries.csv";
            context.Countries.SeedFromResource(resourceName, c => c.Code);

            resourceName = "SeedingDataFromCSV.Domain.SeedData.provincestates.csv";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.WillThrowOnMissingField = false;
                    while (csvReader.Read())
                    {
                        var provinceState = csvReader.GetRecord<ProvinceState>();
                        var countryCode = csvReader.GetField<string>("CountryCode");
                        provinceState.Country = context.Countries.Local.Single(c => c.Code == countryCode);
                        context.ProvinceStates.AddOrUpdate(p => p.Code, provinceState);
                    }
                }
            }
        }
    }
}
