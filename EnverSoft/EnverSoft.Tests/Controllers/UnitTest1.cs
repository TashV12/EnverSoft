using EnverSoft.Controllers;
using EnverSoft.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;

namespace EnverSoft.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {

        private ApplicationDbContext _context;

        // Initialize Context
        public UnitTest1()
        {
            _context = new ApplicationDbContext();
            var cc = new CompanyInfo();
        }
 
        [TestMethod]

        public  void Create([Bind(Exclude = "Id")] CompanyInfo companyInfo)
        {
            // Arrange
            CompanyInfoController controller = new CompanyInfoController();

            // Act
            ViewResult result = controller.Create(companyInfo) as ViewResult;


            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }
    }
}
