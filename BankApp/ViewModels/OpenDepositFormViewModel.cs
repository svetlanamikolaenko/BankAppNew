using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BankApp.Models;

namespace BankApp.ViewModels
{
    public class OpenDepositFormViewModel: Base
    {
        public IEnumerable<Client> Client { get; set; }
        public IEnumerable<Deposit> Deposit { get; set; }
        public OpenDeposit OpenDeposit { get; set; }
    }
}