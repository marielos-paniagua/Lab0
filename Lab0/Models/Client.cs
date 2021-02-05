using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lab0.Models
{
    public class Client
    {
        [Required]
        public int? id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Surname { get; set; }
        [Required]
        public int? Telephone { get; set; }
        [Required]
        public String Description { get; set; }
        



    }
}
