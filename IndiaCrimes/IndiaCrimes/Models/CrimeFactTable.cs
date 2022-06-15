using System;
using System.Collections.Generic;

namespace IndiaCrimes.Models
{
    public partial class CrimeFactTable
    {
        public int CrimeId { get; set; }
        public string Location { get; set; } = null!;
        public int Year { get; set; }
        public int PrecovId { get; set; }
        public int PstoleId { get; set; }
    }
}
