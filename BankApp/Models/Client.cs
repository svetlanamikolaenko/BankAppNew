using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankApp.Models
{
    public class Client: Base
    {
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        public Manager Manager { get; set; }
        public int ManagerId { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
            set { }
        }
    }
}