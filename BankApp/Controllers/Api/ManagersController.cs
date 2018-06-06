using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BankApp.Dtos;
using BankApp.Models;
using System.Data.Entity;

namespace BankApp.Controllers.Api
{
    public class ManagersController : ApiController
    {
        private ApplicationDbContext _context;

        public ManagersController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/managers
        public IHttpActionResult GetManagers()
        {
            var managerDtos = _context.Managers
                .Include(m => m.Role)
                .ToList()
                .Select(Mapper.Map<Manager, ManagerDto>);

            return Ok(managerDtos);
        }

        //GET /api/managers/1
        public IHttpActionResult GetManager(int id)
        {
            var manager = _context.Managers.SingleOrDefault(m => m.Id == id);

            if (manager == null)
                return NotFound();

            return Ok(Mapper.Map<Manager, ManagerDto>(manager));
        }

        //POST /api/managers
        [HttpPost]
        public IHttpActionResult CreateManager(ManagerDto managerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var manager = Mapper.Map<ManagerDto, Manager>(managerDto);
            _context.Managers.Add(manager);
            _context.SaveChanges();

            managerDto.Id = manager.Id;

            return Created(new Uri(Request.RequestUri + "/" + manager.Id), managerDto);
        }

         //PUT /api/managers/1
        [HttpPut]
        public IHttpActionResult UpdateManager(int id, ManagerDto managerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var managerInDb = _context.Managers.SingleOrDefault(m => m.Id == id);

            if (managerInDb == null)
                return NotFound();

            Mapper.Map(managerDto, managerInDb);

            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/managers/1
        [HttpDelete]
        public IHttpActionResult DeleteManager(int id)
        {
            var managerInDb = _context.Managers.SingleOrDefault(m => m.Id == id);

            if (managerInDb == null)
                return NotFound();

            _context.Managers.Remove(managerInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
