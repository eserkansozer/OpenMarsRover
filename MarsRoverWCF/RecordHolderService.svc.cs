using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MarsRover.ORM;
using MarsRover.Services;

namespace MarsRoverWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class RecordHolderService : IRecordHolderService
    {
        public RecordHolderData GetRecordHolder()
        {
            var manager = new RoverManager(new InputParser(), new RoverCommander(), new MarsRoverDbAccessor(new MarsRoverDbContext()));
            var ret = manager.QueryForTheLongestDistanceRover();
            return new RecordHolderData() { Holder = ret };
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }

    [DataContract]
    public class RecordHolderData
    {
        [DataMember]
        public string Holder { get; set; }
    }
}
