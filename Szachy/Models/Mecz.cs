using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Szachy.Models
{
    public class Mecz
    {
        [Key]
        public int Id { get; set; }
        public int Wynik { get; set; }
        public DateTime Data { get; set; }
        [ForeignKey("Id_Bialy")]
        public int Id_Bialy { get; set; }
        
        [ForeignKey("Id_Czarny")]
        public int Id_Czarny { get; set; }
        

    }
}
