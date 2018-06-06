using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using BankApp.Dtos;
using BankApp.Models;

namespace BankApp.Controllers.Api
{
    public class ClientsController : ApiController
    {
        private ApplicationDbContext _context;

        public ClientsController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/clients
        public IHttpActionResult GetClients()
        {
            var clientDtos = _context.Clients
                .Include(c => c.Manager)
                .ToList()
                .Select(Mapper.Map<Client, ClientDto>);

            return Ok(clientDtos);
        }

        //GET /api/clients/1
        public IHttpActionResult GetClient(int id)
        {
            var client = _context.Clients.SingleOrDefault(c => c.Id == id);

            if (client == null)
                return NotFound();

            return Ok(Mapper.Map<Client, ClientDto>(client));
        }

        //POST /api/clients
        [HttpPost]
        public IHttpActionResult CreateClient(ClientDto clientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var client = Mapper.Map<ClientDto, Client>(clientDto);
            _context.Clients.Add(client);
            _context.SaveChanges();

            clientDto.Id = client.Id;

            return Created(new Uri(Request.RequestUri + "/" + client.Id), clientDto);
        }

        //PUT /api/clients/1
        [HttpPut]
        public IHttpActionResult UpdateClient(int id, ClientDto clientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var clientInDb = _context.Clients.SingleOrDefault(c => c.Id == id);

            if (clientInDb == null)
                return NotFound();

            Mapper.Map(clientDto, clientInDb);

            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/clients/1
        [HttpDelete]
        public IHttpActionResult DeleteClient(int id)
        {
            var clientInDb = _context.Clients.SingleOrDefault(c => c.Id == id);

            if (clientInDb == null)
                return NotFound();

            _context.Clients.Remove(clientInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
