using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Naveego.Sdk.Plugins;
using Newtonsoft.Json;
using PluginDariApi.API.Factory;
using PluginDariApi.DataContracts;

namespace PluginDariApi.API.Utility.EndpointHelperEndpoints
{
    public class DariApiEndpointHelper
    {
        private class DariApiEndpoint : Endpoint
        {
            public override bool ShouldGetStaticSchema { get; set; } = true;

            public async override Task<Schema> GetStaticSchemaAsync(IApiClient apiClient, Schema schema)
            {
                List<string> staticSchemaProperties = new List<string>()
                {
                    //keys
                    "appointmentId",
                    
                    //strings
                    "updatedAt",
                    "googleCloudStorageBucket",
                    "reportFilePath",
                    "documentSubclass"
                };
                
                var properties = new List<Property>();

                foreach (var staticProperty in staticSchemaProperties)
                {
                    var property = new Property();

                    property.Id = staticProperty;
                    property.Name = staticProperty;

                    switch (staticProperty)
                    {
                        case ("appointmentId"):
                            property.IsKey = true;
                            property.Type = PropertyType.String;
                            property.TypeAtSource = "string";
                            break;
                        //strings
                        default:
                            property.IsKey = false;
                            property.Type = PropertyType.String;
                            property.TypeAtSource = "string";
                            break;
                    }
                    properties.Add(property);
                }
                schema.Properties.Clear();
                schema.Properties.AddRange(properties);

                schema.DataFlowDirection = GetDataFlowDirection();
                
                return schema;
            }
            
            
            public override async IAsyncEnumerable<Record> ReadRecordsAsync(IApiClient apiClient, Schema schema, bool isDiscoverRead = false)
            {
                var settings = apiClient.GetSettings();
                
                var requestUrl = settings.ApiUrl;
                var response = await apiClient.GetAsync(requestUrl);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }

                var dataWrapper =
                    JsonConvert.DeserializeObject<ResponseWrapper>(await response.Content.ReadAsStringAsync());

                foreach (var session in dataWrapper.Sessions)
                {
                    var recordMap = new Dictionary<string, object>();

                    recordMap["appointmentId"] = session.AppointmentId;
                    recordMap["updatedAt"] = session.UpdatedAt;
                    recordMap["googleCloudStorageBucket"] = session.GoogleCloudStorageBucket;
                    recordMap["reportFilePath"] = session.ReportFilePath;
                    recordMap["documentSubclass"] = session.DocumentSubclass;
                    
                    yield return new Record
                    {
                        Action = Record.Types.Action.Upsert,
                        DataJson = JsonConvert.SerializeObject(recordMap)
                    };
                }
            }
        }

        public static readonly Dictionary<string, Endpoint> DariApiEnpoints = new Dictionary<string, Endpoint>
        {
            {
                "DariApi", new DariApiEndpoint
                {
                    Id = "DariApi",
                    Name = "DariApi",
                    BasePath = "",
                    AllPath = "",
                    PropertiesPath = "",
                    SupportedActions = new List<EndpointActions>
                    {
                        EndpointActions.Get
                    },
                    PropertyKeys = new List<string>
                    {
                        "appointmentId"
                    }
                }
            }
        };
    }
}