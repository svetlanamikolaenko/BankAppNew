using AutoMapper;
using BankApp.Dtos;
using BankApp.Models;
using System;
using System.Web.Http;
using System.Linq;
using System.Data.Entity;


namespace BankApp.Controllers.Api
{
    public class OpenLoansController : ApiController
    {
        private ApplicationDbContext _context;

        public OpenLoansController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/openLoans
        public IHttpActionResult GetOpenLoans()
        {
            var openLoanDtos = _context.OpenLoans
                .Include(o => o.Loan).Include(o=>o.Client)
                .ToList()
                .Select(Mapper.Map<OpenLoan, OpenLoanDto>);

            return Ok(openLoanDtos);
        }

        //GET /api/openLoans/1
        public IHttpActionResult GetOpenLoan(int id)
        {
            var openLoan = _context.OpenLoans.SingleOrDefault(o => o.Id == id);

            if (openLoan == null)
                return NotFound();

            return Ok(Mapper.Map<OpenLoan, OpenLoanDto>(openLoan));
        }

        //POST /api/openLoans
        [HttpPost]
        public IHttpActionResult CreateOpenLoan(OpenLoanDto openLoanDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var openLoan = Mapper.Map<OpenLoanDto, OpenLoan>(openLoanDto);
            _context.OpenLoans.Add(openLoan);
            _context.SaveChanges();

            openLoanDto.Id = openLoan.Id;

            return Created(new Uri(Request.RequestUri + "/" + openLoan.Id), openLoanDto);
        }

        //PUT /api/openLoans/1
        [HttpPut]
        public IHttpActionResult UpdateOpenLoan(int id, OpenLoanDto openLoanDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var openLoanInDb = _context.OpenLoans.SingleOrDefault(c => c.Id == id);

            if (openLoanInDb == null)
                return NotFound();

            Mapper.Map(openLoanDto, openLoanInDb);

            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/openLoans/1
        [HttpDelete]
        public IHttpActionResult DeleteOpenLoan(int id)
        {
            var openLoanInDb = _context.OpenLoans.SingleOrDefault(c => c.Id == id);

            if (openLoanInDb == null)
                return NotFound();

            _context.OpenLoans.Remove(openLoanInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
