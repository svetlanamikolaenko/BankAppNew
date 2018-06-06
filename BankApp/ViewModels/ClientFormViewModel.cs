using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BankApp.Models;

namespace BankApp.ViewModels
{
    public class ClientFormViewModel: Base
    {
        public IEnumerable<Manager> Manager { get; set; }
        public Client Client { get; set; }

        public string Title
        {
            get { return Id != 0 ? "Edit Client" : "New Client"; }
        }
    }
}