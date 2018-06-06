using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankApp.Models;
using BankApp.ViewModels;

namespace BankApp.Controllers
{
    public class DepositsController : Controller
    {
        private ApplicationDbContext _context;

        public DepositsController()
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
            var viewModel = new DepositFormViewModel()
            {
                Deposit = new Deposit(),
            };

            return View("DepositForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Deposit deposit)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new DepositFormViewModel()
                {
                    Deposit = deposit,
                };

                return View("DepositForm", viewModel);
            }

            if (deposit.Id == 0)
                _context.Deposits.Add(deposit);
            else
            {
                var depositInDb = _context.Deposits.Single(d => d.Id == deposit.Id);

                depositInDb.Name = deposit.Name;
                depositInDb.Period = deposit.Period;
                depositInDb.Procent = deposit.Procent;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Deposits");
        }

        public ActionResult Edit(int id)
        {
            var deposit = _context.Deposits.SingleOrDefault(d => d.Id == id);

            if (deposit == null)
                return HttpNotFound();

            var viewModel = new DepositFormViewModel()
            {
                Deposit = deposit,
            };

            return View("DepositForm", viewModel);
        }
    }
}