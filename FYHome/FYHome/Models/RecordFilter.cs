using System;
using System.Collections.Generic;
using System.Text;

namespace FYHomeV1.Models
{
    public class RecordFilter
    {
        public int RecordFilterId { get; set; }
        public int Rooms { get; set; }
        public int ParkingSpaces { get; set; }
        public decimal SalePriceMin { get; set; }
        public decimal SalePriceMax { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Uf { get; set; }
        public string Neighborhood { get; set; }
        public int PersonId { get; set; }
    }
}
