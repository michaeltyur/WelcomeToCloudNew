using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WelcomeToCloud.Shared
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
        public ResponseEntity()
        {
            FrVersion = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;
        }
    }
}