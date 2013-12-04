using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MarsRoverBusinessLogic.Services;
using MarsRoverUI.Models;
using MarsRoverUI.Controllers;

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
            //model.Output = _manager.GenerateGameResultInfo(model.Input)[RoverManager.OUTPUT_TRAIL_KEY];
            //model.Track = _manager.QueryForTheLastTravelledTrack();
            //model.Longest = _manager.QueryForTheLongestDistanceRover();

            return View("Index", model);
        }

        [HttpPost]
        public ActionResult AjaxProcess(string inp)
        {
            var userName = Request.IsAuthenticated ? User.Identity.Name : "Anonymous";
            var result = _manager.GenerateGameResultInfo(userName, inp);
            var output = new {
                FinalLocation = result.ContainsKey(RoverManager.OUTPUT_TRAIL_KEY) ? result[RoverManager.OUTPUT_TRAIL_KEY] : string.Empty,
                RoverCount = result.ContainsKey(RoverManager.ROVER_COUNT_KEY) ? "Number of Rovers: " + result[RoverManager.ROVER_COUNT_KEY] : string.Empty,
                StepCount = result.ContainsKey(RoverManager.STEP_COUNT_KEY) ? "Your Score: " + result[RoverManager.STEP_COUNT_KEY] : string.Empty,
            };
            return Json(output);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Rules()
        {
            return View();
        }
    }

    class GameResult
    {
        public string FinalLocation{get;set;}
    }
}
