using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarsRoverBusinessLogic.Services;
using MarsRoverUI.Models;

namespace MarsRoverBusinessLogic.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        IRoverManager _manager;

        public HomeController(IRoverManager manager)
        {
            _manager = manager;
        }

        public ActionResult Index()
        {
            ViewData.Model = new ViewModel();
            return View("Index");
        }
        
        [HttpPost]
        public ActionResult Process(ViewModel model)
        {           
            model.Output = _manager.GenerateOutputTrailInfo(model.Input);
            model.Track = _manager.QueryForTheLastTravelledTrack();
            model.Longest = _manager.QueryForTheLongestDistanceRover();

            return View("Index", model);
        }

        [HttpPost]
        public ActionResult AjaxProcess(string inp)
        {
            string output = _manager.GenerateOutputTrailInfo(inp);
            return Content(output);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
