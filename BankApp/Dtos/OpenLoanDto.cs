using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankApp.Dtos
{
    public class OpenLoanDto: Base
    {
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public double Amount { get; set; }
        public Loan Loan { get; set; }
        public int LoanId { get; set; }
    }
}