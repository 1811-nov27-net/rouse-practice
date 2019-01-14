using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RESTDemo.Models
{
    public class Temperature
    {
        [Required]
        public int? Id { get; set; }

        [Required]
        public DateTime? Time { get; set; }

        [Required]
        [Range(-200, 1000)]
        public double? Value { get; set; }

        [Required]
        public int Unit { get; set; }

        public string UnitName => GetUnitName(Unit);

        public static string GetUnitName(int id)
        {
            switch (id)
            {
                case 1:
                    return "Celsius";

                case 2:
                    return "Fahrenheit";

                default:
                    return null;
            }
        }

        // Marking the properties as nullable sets their default values to null, which the 'Required' attribute will flag as not valid.  Otherwise, non-null default values will be provided, which 'Required' would see as valid
    }
}
