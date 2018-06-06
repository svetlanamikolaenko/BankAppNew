using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankApp.Models
{
    public class OpenLoan: Base
    {
        public Client Client { get; set; }

        [Display(Name = "Client Name")]
        public int ClientId { get; set; }
        [Required]
        public double? Amount { get; set; }
        public Loan Loan { get; set; }
        [Display(Name = "Loan")]
        public int LoanId { get; set; }
    }
}