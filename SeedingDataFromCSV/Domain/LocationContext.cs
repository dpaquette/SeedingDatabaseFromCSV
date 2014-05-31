using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SeedingDataFromCSV.Domain
{
public class LocationContext : DbContext
{
    public DbSet<Country> Countries { get; set; }
    public DbSet<ProvinceState> ProvinceStates { get; set; }

}
}