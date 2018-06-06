
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankApp.Models;
using BankApp.ViewModels;

namespace BankApp.Controllers
{
    public class LoansController : Controller
    {
        private ApplicationDbContext _context;

        public LoansController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            if (User.IsInRole("Administrator"))
                return View("List");
            return View("ReadOnlyList");
        }

        public ActionResult New()
        {
            var viewModel = new LoanFormViewModel()
            {
                Loan = new Loan(),
            };

            return View("LoanForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Loan loan)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new LoanFormViewModel()
                {
                    Loan = loan,
                };

                return View("LoanForm", viewModel);
            }

            if (loan.Id == 0)
                _context.Loans.Add(loan);
            else
            {
                var loanInDb = _context.Loans.Single(l => l.Id == loan.Id);

                loanInDb.Name = loan.Name;
                loanInDb.Period = loan.Period;
                loanInDb.Procent = loan.Procent;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Loans");
        }

        public ActionResult Edit(int id)
        {
            var loan = _context.Loans.SingleOrDefault(l => l.Id == id);

            if (loan == null)
                return HttpNotFound();

            var viewModel = new LoanFormViewModel()
            {
                Loan = loan,
            };

            return View("LoanForm", viewModel);
        }
    }
}
