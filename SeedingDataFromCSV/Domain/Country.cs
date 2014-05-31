
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeedingDataFromCSV.Domain
{
    public class Country
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual IList<ProvinceState> ProvinceStates { get; set; }
    }
}