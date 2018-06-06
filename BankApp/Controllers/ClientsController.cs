using System.Linq;
using System.Web.Mvc;
using BankApp.Models;
using BankApp.ViewModels;

namespace BankApp.Controllers
{
    public class ClientsController : Controller
    {
        private ApplicationDbContext _context;

        public ClientsController()
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
            var client = _context.Clients.SingleOrDefault(c => c.Id == id);

            if (client == null)
                return HttpNotFound();

            return View(client);
        }

        public ActionResult New()
        {
            var manager = _context.Managers.ToList();
            var viewModel = new ClientFormViewModel
            {
                Client = new Client(),
                Manager = manager
            };

            return View("ClientForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Client client)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ClientFormViewModel()
                {
                    Client = client,
                    Manager = _context.Managers.ToList()
                };

                return View("ClientForm", viewModel);
            }

            if (client.Id == 0)
                _context.Clients.Add(client);
            else
            {
                var clietnInDb = _context.Clients.Single(c => c.Id == client.Id);

                clietnInDb.FirstName = client.FirstName;
                clietnInDb.LastName = client.LastName;
                clietnInDb.ManagerId = client.ManagerId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Clients");
        }

        public ActionResult Edit(int id)
        {
            var client = _context.Clients.SingleOrDefault(c => c.Id == id);

            if (client == null)
                return HttpNotFound();

            var viewModel = new ClientFormViewModel
            {
                Client = client,
                Manager = _context.Managers.ToList()
            };

            return View("ClientForm", viewModel);
        }
    }
}