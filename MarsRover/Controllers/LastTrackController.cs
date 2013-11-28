using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarsRover.Services;
using System.Net.Http;
using System.Threading.Tasks;

namespace MarsRover.Controllers
{
    public class LastTrackController : Controller
    {
        public ActionResult Get()
        {
            string ret = null;
            var task = new HttpClient().GetAsync("http://localhost:52998/api/lasttrack")
                .ContinueWith((requestTask) =>
                {
                    try
                    {
                        HttpResponseMessage response = requestTask.Result;
                        response.EnsureSuccessStatusCode();
                        Task<string> readTask = response.Content.ReadAsAsync<string>();
                        readTask.Wait();
                        ret = readTask.Result;
                    }
                    catch (HttpRequestException e)
                    {                       
                        ret = e.Message;
                    }
                });

            task.Wait();

            return Content(ret);
        }

    }
}
