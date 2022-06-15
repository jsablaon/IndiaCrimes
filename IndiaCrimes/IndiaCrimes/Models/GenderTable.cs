using System;
using System.Collections.Generic;

namespace IndiaCrimes.Models
{
    public partial class GenderTable
    {
        public int GenderId { get; set; }
        public string Gender { get; set; } = null!;
    }
}
