using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Szachy.Models
{
    public class Gracz
    {
        [Key]
        public int Id { get; set; }
        public String Nazwisko { get; set; }
        public String Imie { get; set; }
        public int Ranking { get; set; }
        [Display(Name = "Mężczyzna")]
        public bool Plec { get; set; }
        public int Id_Klub { get; set; }
        [ForeignKey("Id_Klub")]
        public virtual Klub Klub { get; set; }
    }
}
