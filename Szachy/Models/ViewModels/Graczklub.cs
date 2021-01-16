using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Szachy.Models.ViewModels
{
    public class Graczklub
    {
        public Gracz Gracz { get; set; }
        public String Klub { get; set; }
    
        public string StatusMessage { get; set; }
    }
}
