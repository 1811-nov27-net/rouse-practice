using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemperatureWebsite.Models
{
    public class TemperatureRecord
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public double Value { get; set; }

        // Property names and data types must match for (de-)serialization to work properly
        public int Unit { get; set; }

        public string UnitName { get; set; }
    }
}
