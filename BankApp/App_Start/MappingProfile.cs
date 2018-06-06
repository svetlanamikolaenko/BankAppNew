using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BankApp.Dtos;
using BankApp.Models;

namespace BankApp.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            Mapper.CreateMap<Manager, ManagerDto>();
            Mapper.CreateMap<Role, RoleDto>();
            Mapper.CreateMap<Loan, LoanDto>();
            Mapper.CreateMap<Client, ClientDto>();
            Mapper.CreateMap<Deposit, DepositDto>();
            Mapper.CreateMap<OpenLoan, OpenLoanDto>();
            Mapper.CreateMap<OpenDeposit, OpenDepositDto>();


            // Dto to Domain
            Mapper.CreateMap<ManagerDto, Manager>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<ClientDto, Client>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<DepositDto, Deposit>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<LoanDto, Loan>().ForMember(l => l.Id, opt => opt.Ignore());
            Mapper.CreateMap<OpenLoanDto, OpenLoan>().ForMember(o => o.Id, opt => opt.Ignore());
            Mapper.CreateMap<RoleDto, Role>().ForMember(o => o.Id, opt => opt.Ignore());
            Mapper.CreateMap<OpenDepositDto, OpenDeposit>();

        }
    }
}