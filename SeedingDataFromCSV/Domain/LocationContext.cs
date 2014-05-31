using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SeedingDataFromCSV.Domain
{
public class LocationContext : DbContext
{
    public IDbSet<Country> Countries { get; set; }
    public IDbSet<ProvinceState> ProvinceStates { get; set; }

}
}