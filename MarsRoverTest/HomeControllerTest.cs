using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRoverUI.Controllers;
using System.Web.Mvc;
using MarsRoverBusinessLogic.Controllers;
using MarsRoverUI.Models;

namespace MarsRoverTest
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexActionShouldReturnCorrectView()
        {
            var controller = new HomeController(new CannedRoverManager(""));
            var result = controller.Index();
            Assert.AreEqual(result.GetType(), typeof(ViewResult));
            Assert.AreEqual("Index", ((ViewResult)result).ViewName);
        }

        [TestMethod]
        [Ignore]
        public void ProcessActionShouldReturnCorrectView()
        {
            var controller = new HomeController(new CannedRoverManager(""));
            var result = controller.Process(new ViewModel());
            Assert.AreEqual(result.GetType(), typeof(ViewResult));
            Assert.AreEqual("Index", ((ViewResult)result).ViewName);
        }

        [TestMethod]
        public void ProcessActionShouldReturnResultFromRoverManager()
        {
            var controller = new HomeController(new CannedRoverManager("xyz"));
            var result = controller.Process(new ViewModel());
            Assert.AreEqual("xyz", ((ViewModel)((ViewResult)result).ViewData.Model).Output);
        }
    }
}
