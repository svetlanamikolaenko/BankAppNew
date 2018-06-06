using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BankApp.Dtos;
using BankApp.Models;

namespace BankApp.Controllers.Api
{
    public class OpenDepositsController : ApiController
    {
        private ApplicationDbContext _context;

        public OpenDepositsController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/openDeposits
        public IHttpActionResult GetOpenDeposits()
        {
            var openDepositDtos = _context.OpenDeposits
                .Include(o => o.Deposit).Include(o => o.Client)
                .ToList()
                .Select(Mapper.Map<OpenDeposit, OpenDepositDto>);

            return Ok(openDepositDtos);
        }

        //GET /api/openDeposits/1
        public IHttpActionResult GetOpenDeposit(int id)
        {
            var openDeposit = _context.OpenDeposits.SingleOrDefault(o => o.Id == id);

            if (openDeposit == null)
                return NotFound();

            return Ok(Mapper.Map<OpenDeposit, OpenDepositDto>(openDeposit));
        }

        //POST /api/openDeposits
        [HttpPost]
        public IHttpActionResult CreateOpenDeposit(OpenDepositDto openDepositDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var openDeposit = Mapper.Map<OpenDepositDto, OpenDeposit>(openDepositDto);
            _context.OpenDeposits.Add(openDeposit);
            _context.SaveChanges();

            openDepositDto.Id = openDeposit.Id;

            return Created(new Uri(Request.RequestUri + "/" + openDeposit.Id), openDepositDto);
        }

        //PUT /api/openDeposits/1
        [HttpPut]
        public IHttpActionResult UpdateOpenDeposit(int id, OpenDepositDto openDepositDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var openDepositInDb = _context.OpenDeposits.SingleOrDefault(d => d.Id == id);

            if (openDepositInDb == null)
                return NotFound();

            Mapper.Map(openDepositDto, openDepositInDb);

            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/openDeposits/1
        [HttpDelete]
        public IHttpActionResult DeleteOpenDeposit(int id)
        {
            var openDepositInDb = _context.OpenDeposits.SingleOrDefault(d => d.Id == id);

            if (openDepositInDb == null)
                return NotFound();

            _context.OpenDeposits.Remove(openDepositInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
