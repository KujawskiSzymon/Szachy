using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Szachy.Models.ViewModels
{
    public class GraczMecz
    {
        public string GraczANazwisko { get; set; }
        public string GraczAImie { get; set; }
        public string GraczBNazwisko { get; set; }
        public string GraczBImie { get; set; }
        public Mecz Mecz { get; set; }
        public string wynik { get; set; }
    
        public string StatusMessage { get; set; }
    }
}
