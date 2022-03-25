using System.Collections.Generic;
using Newtonsoft.Json;

namespace PluginDariApi.DataContracts
{
    public class ResponseWrapper
    {
        [JsonProperty("info")]
        public Info Info { get; set; }
        
        [JsonProperty("sessions")]
        public List<Session> Sessions { get; set; }
    }

    public class Info
    {
        [JsonProperty("status")]
        public int Status { get; set; }
        
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class Session
    {
        [JsonProperty("appointmentId")]
        public string AppointmentId { get; set; }
        
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }
        
        [JsonProperty("googleCloudStorageBucket")]
        public string GoogleCloudStorageBucket { get; set; }
        
        [JsonProperty("reportFilePath")]
        public string ReportFilePath { get; set; }
        
        [JsonProperty("documentSubclass")]
        public string DocumentSubclass { get; set; }
    }
}