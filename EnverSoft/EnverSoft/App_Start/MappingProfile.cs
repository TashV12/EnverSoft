using AutoMapper;
using EnverSoft.Dtos;
using EnverSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnverSoft.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<CompanyInfo, CompanyDto>();
            Mapper.CreateMap<CompanyDto, CompanyInfo>();
        }
    }
}