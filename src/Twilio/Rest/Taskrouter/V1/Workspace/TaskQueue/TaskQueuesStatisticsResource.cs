using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace.TaskQueue 
{

    public class TaskQueuesStatisticsResource : Resource 
    {
        private static Request BuildReadRequest(ReadTaskQueuesStatisticsOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/TaskQueues/Statistics",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="options"> Read TaskQueuesStatistics parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of TaskQueuesStatistics </returns> 
        public static ResourceSet<TaskQueuesStatisticsResource> Read(ReadTaskQueuesStatisticsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<TaskQueuesStatisticsResource>.FromJson("task_queues_statistics", response.Content);
            return new ResourceSet<TaskQueuesStatisticsResource>(page, options, client);
        }
    
        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="options"> Read TaskQueuesStatistics parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of TaskQueuesStatistics </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<TaskQueuesStatisticsResource>> ReadAsync(ReadTaskQueuesStatisticsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));
            
            var page = Page<TaskQueuesStatisticsResource>.FromJson("task_queues_statistics", response.Content);
            return new ResourceSet<TaskQueuesStatisticsResource>(page, options, client);
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="endDate"> The end_date </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="minutes"> The minutes </param>
        /// <param name="startDate"> The start_date </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of TaskQueuesStatistics </returns> 
        public static ResourceSet<TaskQueuesStatisticsResource> Read(string workspaceSid, DateTime? endDate = null, string friendlyName = null, int? minutes = null, DateTime? startDate = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadTaskQueuesStatisticsOptions(workspaceSid){EndDate = endDate, FriendlyName = friendlyName, Minutes = minutes, StartDate = startDate, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="endDate"> The end_date </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="minutes"> The minutes </param>
        /// <param name="startDate"> The start_date </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of TaskQueuesStatistics </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<TaskQueuesStatisticsResource>> ReadAsync(string workspaceSid, DateTime? endDate = null, string friendlyName = null, int? minutes = null, DateTime? startDate = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadTaskQueuesStatisticsOptions(workspaceSid){EndDate = endDate, FriendlyName = friendlyName, Minutes = minutes, StartDate = startDate, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        ///
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns> 
        public static Page<TaskQueuesStatisticsResource> NextPage(Page<TaskQueuesStatisticsResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Taskrouter,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<TaskQueuesStatisticsResource>.FromJson("task_queues_statistics", response.Content);
        }
    
        /// <summary>
        /// Converts a JSON string into a TaskQueuesStatisticsResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TaskQueuesStatisticsResource object represented by the provided JSON </returns> 
        public static TaskQueuesStatisticsResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<TaskQueuesStatisticsResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        /// <summary>
        /// The account_sid
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// The cumulative
        /// </summary>
        [JsonProperty("cumulative")]
        public object Cumulative { get; private set; }
        /// <summary>
        /// The realtime
        /// </summary>
        [JsonProperty("realtime")]
        public object Realtime { get; private set; }
        /// <summary>
        /// The task_queue_sid
        /// </summary>
        [JsonProperty("task_queue_sid")]
        public string TaskQueueSid { get; private set; }
        /// <summary>
        /// The workspace_sid
        /// </summary>
        [JsonProperty("workspace_sid")]
        public string WorkspaceSid { get; private set; }
    
        private TaskQueuesStatisticsResource()
        {
        
        }
    }

}