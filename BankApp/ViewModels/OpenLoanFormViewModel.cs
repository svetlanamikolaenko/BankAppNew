using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankApp.ViewModels
{
    public class OpenLoanFormViewModel: Base
    {
        public IEnumerable<Client> Client { get; set; }
        public IEnumerable<Loan> Loan { get; set; }
        public OpenLoan OpenLoan { get; set; }
    }
}