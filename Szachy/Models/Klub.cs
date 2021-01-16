using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Szachy.Models
{
    public class Klub
    {
        [Key]
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Liga { get; set; }

    }
}
