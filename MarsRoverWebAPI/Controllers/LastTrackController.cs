using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MarsRover.Services;
using MarsRover.ORM;

namespace MarsRoverWebAPI.Controllers
{
    public class LastTrackController : ApiController
    {
        // GET api/lasttrack
        public string Get()
        {
            var manager = new RoverManager(new InputParser(), new RoverCommander(), new MarsRoverDbAccessor(new MarsRoverDbContext()));
            var ret = manager.QueryForTheLastTravelledTrack();
            if (ret == null || ret == String.Empty)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return ret;            
        }

        //// GET api/lasttrack/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/lasttrack
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/lasttrack/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/lasttrack/5
        //public void Delete(int id)
        //{
        //}
    }
}
