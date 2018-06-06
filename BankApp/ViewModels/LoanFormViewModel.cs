using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BankApp.Models;

namespace BankApp.ViewModels
{
    public class LoanFormViewModel: Product
    {
        public Loan Loan { get; set; }

        public string Title
        {
            get { return Id != 0 ? "Edit Loan" : "New Loan"; }
        }
    }
}
