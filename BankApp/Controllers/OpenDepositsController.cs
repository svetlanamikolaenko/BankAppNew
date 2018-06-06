using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankApp.Models;
using BankApp.ViewModels;

namespace BankApp.Controllers
{
    public class OpenDepositsController : Controller
    {
        private ApplicationDbContext _context;

        public OpenDepositsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var deposit = _context.Deposits.ToList();
            var client = _context.Clients.ToList();
            var viewModel = new OpenDepositFormViewModel
            {
                OpenDeposit = new OpenDeposit(),
                Deposit = deposit,
                Client = client
            };

            return View("New", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(OpenDeposit openDeposit)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new OpenDepositFormViewModel()
                {
                    OpenDeposit = openDeposit,
                    Deposit = _context.Deposits.ToList(),
                    Client = _context.Clients.ToList()
                };

                return View("New", viewModel);
            }

            if (openDeposit.Id == 0)
                _context.OpenDeposits.Add(openDeposit);
            else
            {
                var openDepositInDb = _context.OpenDeposits.Single(d => d.Id == openDeposit.Id);

                openDepositInDb.Deposit.Name = openDeposit.Deposit.Name;
                openDepositInDb.Deposit.Period = openDeposit.Deposit.Period;
                openDepositInDb.Deposit.Procent = openDeposit.Deposit.Procent;
                openDepositInDb.Client.FullName = openDeposit.Client.FullName;
                openDepositInDb.Amount = openDeposit.Amount;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "OpenDeposits");
        }
    }
}