using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

namespace WelcomeToCloud.Web.Api.Framework
{
    public class ResponseEntity
    {
        [JsonProperty("metaData")]
        public string MetaData { get; set; }
        [JsonProperty("data")]
        public string Data { get; set; }
        [JsonProperty("frVersion")]
        public string FrVersion { get; set; }
        [JsonProperty("currentUser")]
        public string CurrentUser { get; set; }
        [JsonProperty("timeStamp")]
        public DateTime TimeStamp { get; set; }
        [JsonProperty("impersonatedUser")]
        public string ImpersonatedUser { get; set; }
        public ResponseEntity()
        {
            FrVersion = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;
            TimeStamp = DateTime.Now;
        }
    }
}