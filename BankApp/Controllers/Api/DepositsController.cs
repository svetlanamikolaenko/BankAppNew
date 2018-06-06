using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BankApp.Dtos;
using BankApp.Models;

namespace BankApp.Controllers.Api
{
    public class DepositsController : ApiController
    {
        private ApplicationDbContext _context;

        public DepositsController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/deposits
        public IHttpActionResult GetDeposits()
        {
            var depositDtos = _context.Deposits.ToList().Select(Mapper.Map<Deposit, DepositDto>);

            return Ok(depositDtos);
        }

        //GET /api/deposits/1
        public IHttpActionResult GetDeposits(int id)
        {
            var deposit = _context.Deposits.SingleOrDefault(d => d.Id == id);

            if (deposit == null)
                return NotFound();

            return Ok(Mapper.Map<Deposit, DepositDto>(deposit));
        }

        //POST /api/deposits
        [HttpPost]
        public IHttpActionResult CreateDeposit(DepositDto depositDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var deposit = Mapper.Map<DepositDto, Deposit>(depositDto);
            _context.Deposits.Add(deposit);
            _context.SaveChanges();

            depositDto.Id = deposit.Id;

            return Created(new Uri(Request.RequestUri + "/" + deposit.Id), depositDto);
        }

        //PUT /api/deposits/1
        [HttpPut]
        public IHttpActionResult UpdateDeposit(int id, DepositDto depositDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var depositInDb = _context.Deposits.SingleOrDefault(d => d.Id == id);

            if (depositInDb == null)
                return NotFound();

            Mapper.Map(depositDto, depositInDb);

            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/deposits/1
        [HttpDelete]
        public IHttpActionResult DeleteDeposit(int id)
        {
            var depositInDb = _context.Deposits.SingleOrDefault(d => d.Id == id);

            if (depositInDb == null)
                return NotFound();

            _context.Deposits.Remove(depositInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
