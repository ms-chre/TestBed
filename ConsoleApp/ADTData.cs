using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class DigitalTwinsFileInfo
    {
        public string fileVersion { get; set; }
    }

    public class Metadata
    {
        [JsonProperty("$model")]
        public string Model { get; set; }
    }

    public class DigitalTwin
    {
        [JsonProperty("$dtId")]
        public string DtId { get; set; }

        [JsonProperty("$etag")]
        public string Etag { get; set; }
        public string pollFrequency { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string regionId { get; set; }
        public string buildingId { get; set; }
        public string floorId { get; set; }
        public string status { get; set; }
        public string brandName { get; set; }
        public string hardwareId { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime lastModifiedDate { get; set; }

        [JsonProperty("$metadata")]
        public Metadata Metadata { get; set; }
        public string externalId { get; set; }
    }

    public class DigitalTwinsGraph
    {
        public List<DigitalTwin> digitalTwins { get; set; }
        public List<object> relationships { get; set; }
    }

    public class Property
    {
        [JsonProperty("@type")]
        public string Type { get; set; }
        public string name { get; set; }
        public string schema { get; set; }
    }

    public class Content
    {
        [JsonProperty("@type")]
        public string Type { get; set; }
        public string name { get; set; }
        public bool writable { get; set; }
        public object schema { get; set; }
        public string comment { get; set; }
        public string target { get; set; }
        public int? maxMultiplicity { get; set; }
        public string description { get; set; }
        public List<Property> properties { get; set; }
    }

    public class EnumValue
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public string enumValue { get; set; }
        public string comment { get; set; }
    }

    public class Schema
    {
        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }
        public string valueSchema { get; set; }
        public List<EnumValue> enumValues { get; set; }
    }

    public class DigitalTwinsModel
    {
        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("@context")]
        public List<string> Context { get; set; }
        public string displayName { get; set; }
        public string extends { get; set; }
        public List<Content> contents { get; set; }
        public List<Schema> schemas { get; set; }
    }

    public class ADTData
    {
        public DigitalTwinsFileInfo digitalTwinsFileInfo { get; set; }
        public DigitalTwinsGraph digitalTwinsGraph { get; set; }
       /* public List<DigitalTwinsModel> digitalTwinsModels { get; set; }*/
    }
}
