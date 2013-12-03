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
            model.Output = _manager.GenerateGameResultInfo(model.Input)[RoverManager.OUTPUT_TRAIL_KEY];
            model.Track = _manager.QueryForTheLastTravelledTrack();
            model.Longest = _manager.QueryForTheLongestDistanceRover();

            return View("Index", model);
        }

        [HttpPost]
        public ActionResult AjaxProcess(string inp)
        {
            var output = new {
                FinalLocation ="FinalLocation(s): " + _manager.GenerateGameResultInfo(inp)[RoverManager.OUTPUT_TRAIL_KEY],
                RoverCount = "Number or Rovers: " + _manager.GenerateGameResultInfo(inp)[RoverManager.ROVER_COUNT_KEY],
                StepCount = "Number of Total Steps: " + _manager.GenerateGameResultInfo(inp)[RoverManager.STEP_COUNT_KEY],
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
