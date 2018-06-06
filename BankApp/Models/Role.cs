using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankApp.Models
{
    public class Role : Base
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}