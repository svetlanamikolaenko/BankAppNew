using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BankApp.Models;

namespace BankApp.ViewModels
{
    public class DepositFormViewModel: Product
    {
        public Deposit Deposit { get; set; }
        public string Title
        {
            get { return Id != 0 ? "Edit Deposit" : "New Deposit"; }
        }
    }
}