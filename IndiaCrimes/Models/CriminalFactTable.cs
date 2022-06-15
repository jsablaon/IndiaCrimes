using System;
using System.Collections.Generic;

namespace IndiaCrimes.Models
{
    public partial class CriminalFactTable
    {
        public int CriminalId { get; set; }
        public string Location { get; set; } = null!;
        public int Year { get; set; }
        public int GenderId { get; set; }
        public int AsixtnUid { get; set; }
        public int AeightntothirtId { get; set; }
        public int AthirttofithId { get; set; }
        public int AfithabovId { get; set; }
    }
}
