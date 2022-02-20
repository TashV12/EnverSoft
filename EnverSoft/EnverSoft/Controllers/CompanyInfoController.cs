using EnverSoft.Models;
using EnverSoft.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnverSoft.Controllers
{
    public class CompanyInfoController : Controller
    {

        private ApplicationDbContext _context;

        // Initialize Context
        public CompanyInfoController()
        {
            _context = new ApplicationDbContext();
            var cc = new CompanyInfo();
        }

        //Disposing Context
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var viewModel = new CompanyInfoViewModel();
 
            return View("New", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")] CompanyInfo companyInfo)
        {
            if (!ModelState.IsValid)
            {
               
                var viewModel = new CompanyInfoViewModel
                {
                    companyInfo = companyInfo,

                };
                return View("New", viewModel);


            }
            else
            {
                if (companyInfo.Id == 0)
                {

                    _context.CompanyInfos.Add(companyInfo);
                }
                else
                {
                    var companyInfoInDb = _context.CompanyInfos.Single(m => m.Id == companyInfo.Id);

                    companyInfoInDb.Name = companyInfo.Name;
                    companyInfoInDb.PhoneNumber = companyInfo.PhoneNumber;
                }

                _context.SaveChanges();
            }
            return RedirectToAction("Index", "CompanyInfo");
        }

        public ViewResult Index()
        {
            var companyInfo = _context.CompanyInfos.ToList();
            return View(companyInfo);
        }

        public ActionResult Details(int id)
        {
        

            var companyInfo = _context.CompanyInfos.SingleOrDefault(c => c.Id == id);

            if (companyInfo == null)
            {
                return HttpNotFound();
            }

            return View(companyInfo);
        }

        public ActionResult Edit(int id)
        {
            var companyInfo = _context.CompanyInfos.SingleOrDefault(c => c.Id == id);

            if(companyInfo == null)
            {
                return HttpNotFound();

            }

            var viewModel = new CompanyInfoViewModel()
            {
                companyInfo = companyInfo
            };
            return View("New", viewModel);
        }
      


    }
}