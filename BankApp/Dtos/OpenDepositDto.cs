using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BankApp.Models;

namespace BankApp.Dtos
{
    public class OpenDepositDto: Base
    {
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public double Amount { get; set; }
        public Deposit Deposit { get; set; }
        public int DepositId { get; set; }
    }
}