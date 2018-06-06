using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankApp.ViewModels;

namespace BankApp.Controllers
{
    public class OpenLoansController : Controller
    {
        private ApplicationDbContext _context;

        public OpenLoansController()
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
            var loan = _context.Loans.ToList();
            var client = _context.Clients.ToList();
            var viewModel = new OpenLoanFormViewModel
            {
                OpenLoan = new OpenLoan(),
                Loan = loan,
                Client = client
            };

            return View("New", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(OpenLoan openLoan)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new OpenLoanFormViewModel()
                {
                    OpenLoan = openLoan,
                    Loan = _context.Loans.ToList(),
                    Client = _context.Clients.ToList()
                };

                return View("New", viewModel);
            }

            if (openLoan.Id == 0)
                _context.OpenLoans.Add(openLoan);
            else
            {
                var openLoanInDb = _context.OpenLoans.Single(c => c.Id == openLoan.Id);

                openLoanInDb.Loan.Name = openLoan.Loan.Name;
                openLoanInDb.Loan.Period = openLoan.Loan.Period;
                openLoanInDb.Loan.Procent = openLoan.Loan.Procent;
                openLoanInDb.Client.FullName = openLoan.Client.FullName;
                openLoanInDb.Amount = openLoan.Amount;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "OpenLoans");
        }
    }
}