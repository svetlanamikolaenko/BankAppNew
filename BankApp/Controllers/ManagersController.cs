using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankApp.Models;
using BankApp.ViewModels;

namespace BankApp.Controllers
{
    public class ManagersController : Controller
    {
        private ApplicationDbContext _context;

        public ManagersController()
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

        public ActionResult Details(int id)
        {
            var manager = _context.Managers.SingleOrDefault(c => c.Id == id);

            if (manager == null)
                return HttpNotFound();

            return View(manager);
        }

        public ActionResult New()
        {
            var role = _context.Roles.ToList();
            var viewModel = new ManagerFormViewModel
            {
                Manager = new Manager(),
                Role = role
            };

            return View("ManagerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Manager manager)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ManagerFormViewModel()
                {
                    Manager = manager,
                    Role = _context.Roles.ToList()
                };

                return View("ManagerForm", viewModel);
            }

            if (manager.Id == 0) 
                _context.Managers.Add(manager);
            else
            {
                var managerInDb = _context.Managers.Single(m => m.Id == manager.Id);

                managerInDb.FirstName = manager.FirstName;
                managerInDb.LastName = manager.LastName;
                managerInDb.RoleId = manager.RoleId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Managers");
        }

        public ActionResult Edit(int id)
        {
            var manager = _context.Managers.SingleOrDefault(m => m.Id == id);

            if (manager == null)
                return HttpNotFound();

            var viewModel = new ManagerFormViewModel
            {
                Manager = manager,
                Role = _context.Roles.ToList()
            };

            return View("ManagerForm", viewModel);
        }
    }
}