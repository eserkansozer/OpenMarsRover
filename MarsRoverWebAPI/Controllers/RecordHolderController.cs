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
    public class RecordHolderController : ApiController
    {
        // GET api/recordholder
        public RecordHolder Get()
        {
            var manager = new RoverManager(new InputParser(), new RoverCommander(), new MarsRoverDbAccessor(new MarsRoverDbContext()));
            var ret = manager.QueryForTheLongestDistanceRover();
            return new RecordHolder() { Holder = ret };
        }

        //// GET api/recordholder/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/recordholder
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/recordholder/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/recordholder/5
        //public void Delete(int id)
        //{
        //}
    }
}
