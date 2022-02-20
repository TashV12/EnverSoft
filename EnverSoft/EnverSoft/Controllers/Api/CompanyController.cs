using AutoMapper;
using EnverSoft.Dtos;
using EnverSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EnverSoft.Controllers.Api
{
    public class CompanyController : ApiController
    {
        private ApplicationDbContext _context;

        public CompanyController()
        {
            _context = new ApplicationDbContext();
        }
        //GET/api/companyInfos
        public IEnumerable<CompanyDto> GetCompanyInfos()
        {
            return _context.CompanyInfos.ToList().Select(Mapper.Map<CompanyInfo, CompanyDto>);
        }

        //GET/api/companyInfos/1
        //
        public IHttpActionResult GetCompanyInfo(int id)
        {
            var comp = _context.CompanyInfos.SingleOrDefault(c => c.Id == id);

            if (comp == null)

                return NotFound();
            return Ok (Mapper.Map<CompanyInfo, CompanyDto>(comp));


        }

        //POST/api/company
        [HttpPost]
        public IHttpActionResult CreateCompanyInfo(CompanyDto companyDto)
        {
            if (ModelState.IsValid)

                return BadRequest();

            var compInfo = Mapper.Map<CompanyDto, CompanyInfo>(companyDto);
            _context.CompanyInfos.Add(compInfo);
            _context.SaveChanges();

            companyDto.Id = compInfo.Id;
           

            return Created(new Uri(Request.RequestUri+"/"+ compInfo.Id), companyDto);
        }

        //PUT/api/company/1
        [HttpPut]
       public void UpdateCustomer(int id, CompanyDto companyDto)
        {
            if (ModelState.IsValid)

                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var compInDb = _context.CompanyInfos.SingleOrDefault(c => c.Id == id);

            if(compInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<CompanyDto, CompanyInfo>(companyDto, compInDb);
            //compInDb.Name = companyDto.Name;
            //compInDb.PhoneNumber = companyDto.PhoneNumber;

            _context.SaveChanges();
       
        }

        //DELETE/api/company/1
        [HttpDelete]
        public void DeleteCompany(int id)
        {
            var compInDb = _context.CompanyInfos.SingleOrDefault(c => c.Id == id);

            if (compInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.CompanyInfos.Remove(compInDb);
            _context.SaveChanges();
        }
    }
}
