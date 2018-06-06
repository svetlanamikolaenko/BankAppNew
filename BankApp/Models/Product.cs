using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankApp.Models
{
    public class Product: Base
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public int? Period { get; set; }
        [Required]
        [Range(1,100)]
        public int? Procent { get; set; }
        
    }
}