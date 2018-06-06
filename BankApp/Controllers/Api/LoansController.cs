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
    public class LoansController : ApiController
    {
        private ApplicationDbContext _context;

        public LoansController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/loans
        public IHttpActionResult GetLoans()
        {
            var loanDtos = _context.Loans.ToList().Select(Mapper.Map<Loan, LoanDto>);

            return Ok(loanDtos);
        }

        //GET /api/loans/1
        public IHttpActionResult GetLoans(int id)
        {
            var loan = _context.Loans.SingleOrDefault(l => l.Id == id);

            if (loan == null)
                return NotFound();

            return Ok(Mapper.Map<Loan, LoanDto>(loan));
        }

        //POST /api/loans
        [HttpPost]
        public IHttpActionResult CreateLoan(LoanDto loanDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var loan = Mapper.Map<LoanDto, Loan>(loanDto);
            _context.Loans.Add(loan);
            _context.SaveChanges();

            loanDto.Id = loan.Id;

            return Created(new Uri(Request.RequestUri + "/" + loan.Id), loanDto);
        }

        //PUT /api/loans/1
        [HttpPut]
        public IHttpActionResult UpdateLoan(int id, LoanDto loanDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var loanInDb = _context.Loans.SingleOrDefault(l => l.Id == id);

            if (loanInDb == null)
                return NotFound();

            Mapper.Map(loanDto, loanInDb);

            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/loans/1
        [HttpDelete]
        public IHttpActionResult DeleteLoan(int id)
        {
            var loanInDb = _context.Loans.SingleOrDefault(l => l.Id == id);

            if (loanInDb == null)
                return NotFound();

            _context.Loans.Remove(loanInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}



