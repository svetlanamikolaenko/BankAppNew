using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BankApp.Models;

namespace BankApp.ViewModels
{
    public class ManagerFormViewModel: Base
    {
        public IEnumerable<Role> Role { get; set; }
        public Manager Manager { get; set; }

        public string Title
        {
            get { return Id != 0 ? "Edit Manager" : "New Manager"; }
        }
    }
}