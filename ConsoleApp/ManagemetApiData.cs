using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class ManagemetApiData
    {
        public string name { get; set; }
        public string friendlyName { get; set; }
        public object description { get; set; }
        public string type { get; set; }
        public string subtype { get; set; }
        public int typeId { get; set; }
        public int subtypeId { get; set; }
        public string hardwareId { get; set; }
        public string gatewayId { get; set; }
        public string spaceId { get; set; }
        public string status { get; set; }
        public object location { get; set; }
        public string id { get; set; }
        public object connectionState { get; set; }
        public object connectionStateUpdatedTime { get; set; }
        public object ioTHubUrl { get; set; }
        public object deviceKey { get; set; }
        public object sasToken { get; set; }
        public object connectionString { get; set; }
        public object space { get; set; }
        public object sensors { get; set; }
        public object fullName { get; set; }
        public object spacePaths { get; set; }
        public object effectiveLocation { get; set; }
        public object properties { get; set; }
        public object iotHubResource { get; set; }
        public object deviceIngressDomainResource { get; set; }
        public object roleAssignments { get; set; }
    }
}
