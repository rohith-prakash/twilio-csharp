using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Preview.Proxy.Service 
{

    /// <summary>
    /// SessionResource
    /// </summary>
    public class SessionResource : Resource 
    {
        public sealed class StatusEnum : StringEnum 
        {
            private StatusEnum(string value) : base(value) {}
            public StatusEnum() {}

            public static readonly StatusEnum InProgess = new StatusEnum("in-progess");
            public static readonly StatusEnum Completed = new StatusEnum("completed");
        }

        private static Request BuildFetchRequest(FetchSessionOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/Proxy/Services/" + options.PathServiceSid + "/Sessions/" + options.PathSid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Fetch a specific Session.
        /// </summary>
        ///
        /// <param name="options"> Fetch Session parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Session </returns> 
        public static SessionResource Fetch(FetchSessionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Fetch a specific Session.
        /// </summary>
        ///
        /// <param name="options"> Fetch Session parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Session </returns> 
        public static async System.Threading.Tasks.Task<SessionResource> FetchAsync(FetchSessionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Fetch a specific Session.
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        /// <param name="pathSid"> A string that uniquely identifies this Session. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Session </returns> 
        public static SessionResource Fetch(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchSessionOptions(pathServiceSid, pathSid);
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// Fetch a specific Session.
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        /// <param name="pathSid"> A string that uniquely identifies this Session. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Session </returns> 
        public static async System.Threading.Tasks.Task<SessionResource> FetchAsync(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchSessionOptions(pathServiceSid, pathSid);
            return await FetchAsync(options, client);
        }
        #endif

        private static Request BuildReadRequest(ReadSessionOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/Proxy/Services/" + options.PathServiceSid + "/Sessions",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Retrieve a list of all Sessions for a Service.
        /// </summary>
        ///
        /// <param name="options"> Read Session parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Session </returns> 
        public static ResourceSet<SessionResource> Read(ReadSessionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));

            var page = Page<SessionResource>.FromJson("sessions", response.Content);
            return new ResourceSet<SessionResource>(page, options, client);
        }

        #if !NET35
        /// <summary>
        /// Retrieve a list of all Sessions for a Service.
        /// </summary>
        ///
        /// <param name="options"> Read Session parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Session </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<SessionResource>> ReadAsync(ReadSessionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<SessionResource>.FromJson("sessions", response.Content);
            return new ResourceSet<SessionResource>(page, options, client);
        }
        #endif

        /// <summary>
        /// Retrieve a list of all Sessions for a Service.
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        /// <param name="uniqueName"> A unique, developer assigned name of this Session. </param>
        /// <param name="status"> The Status of this Session </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Session </returns> 
        public static ResourceSet<SessionResource> Read(string pathServiceSid, string uniqueName = null, SessionResource.StatusEnum status = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadSessionOptions(pathServiceSid){UniqueName = uniqueName, Status = status, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary>
        /// Retrieve a list of all Sessions for a Service.
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        /// <param name="uniqueName"> A unique, developer assigned name of this Session. </param>
        /// <param name="status"> The Status of this Session </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Session </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<SessionResource>> ReadAsync(string pathServiceSid, string uniqueName = null, SessionResource.StatusEnum status = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadSessionOptions(pathServiceSid){UniqueName = uniqueName, Status = status, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        /// <summary>
        /// Fetch the target page of records
        /// </summary>
        ///
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns> 
        public static Page<SessionResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<SessionResource>.FromJson("sessions", response.Content);
        }

        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        ///
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns> 
        public static Page<SessionResource> NextPage(Page<SessionResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Preview,
                    client.Region
                )
            );

            var response = client.Request(request);
            return Page<SessionResource>.FromJson("sessions", response.Content);
        }

        /// <summary>
        /// Fetch the previous page of records
        /// </summary>
        ///
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns> 
        public static Page<SessionResource> PreviousPage(Page<SessionResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(
                    Rest.Domain.Preview,
                    client.Region
                )
            );

            var response = client.Request(request);
            return Page<SessionResource>.FromJson("sessions", response.Content);
        }

        private static Request BuildCreateRequest(CreateSessionOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                "/Proxy/Services/" + options.PathServiceSid + "/Sessions",
                client.Region,
                postParams: options.GetParams()
            );
        }

        /// <summary>
        /// Start a new Session
        /// </summary>
        ///
        /// <param name="options"> Create Session parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Session </returns> 
        public static SessionResource Create(CreateSessionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Start a new Session
        /// </summary>
        ///
        /// <param name="options"> Create Session parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Session </returns> 
        public static async System.Threading.Tasks.Task<SessionResource> CreateAsync(CreateSessionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Start a new Session
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        /// <param name="uniqueName"> A unique, developer assigned name of this Session. </param>
        /// <param name="ttl"> How long will this session stay open, in seconds. </param>
        /// <param name="status"> The Status of this Session </param>
        /// <param name="participants"> The participants </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Session </returns> 
        public static SessionResource Create(string pathServiceSid, string uniqueName = null, int? ttl = null, SessionResource.StatusEnum status = null, List<string> participants = null, ITwilioRestClient client = null)
        {
            var options = new CreateSessionOptions(pathServiceSid){UniqueName = uniqueName, Ttl = ttl, Status = status, Participants = participants};
            return Create(options, client);
        }

        #if !NET35
        /// <summary>
        /// Start a new Session
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        /// <param name="uniqueName"> A unique, developer assigned name of this Session. </param>
        /// <param name="ttl"> How long will this session stay open, in seconds. </param>
        /// <param name="status"> The Status of this Session </param>
        /// <param name="participants"> The participants </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Session </returns> 
        public static async System.Threading.Tasks.Task<SessionResource> CreateAsync(string pathServiceSid, string uniqueName = null, int? ttl = null, SessionResource.StatusEnum status = null, List<string> participants = null, ITwilioRestClient client = null)
        {
            var options = new CreateSessionOptions(pathServiceSid){UniqueName = uniqueName, Ttl = ttl, Status = status, Participants = participants};
            return await CreateAsync(options, client);
        }
        #endif

        private static Request BuildDeleteRequest(DeleteSessionOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Preview,
                "/Proxy/Services/" + options.PathServiceSid + "/Sessions/" + options.PathSid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Delete a specific Session.
        /// </summary>
        ///
        /// <param name="options"> Delete Session parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Session </returns> 
        public static bool Delete(DeleteSessionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary>
        /// Delete a specific Session.
        /// </summary>
        ///
        /// <param name="options"> Delete Session parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Session </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteSessionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary>
        /// Delete a specific Session.
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        /// <param name="pathSid"> A string that uniquely identifies this Session. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Session </returns> 
        public static bool Delete(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteSessionOptions(pathServiceSid, pathSid);
            return Delete(options, client);
        }

        #if !NET35
        /// <summary>
        /// Delete a specific Session.
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        /// <param name="pathSid"> A string that uniquely identifies this Session. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Session </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteSessionOptions(pathServiceSid, pathSid);
            return await DeleteAsync(options, client);
        }
        #endif

        private static Request BuildUpdateRequest(UpdateSessionOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                "/Proxy/Services/" + options.PathServiceSid + "/Sessions/" + options.PathSid + "",
                client.Region,
                postParams: options.GetParams()
            );
        }

        /// <summary>
        /// Update a specific Session.
        /// </summary>
        ///
        /// <param name="options"> Update Session parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Session </returns> 
        public static SessionResource Update(UpdateSessionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Update a specific Session.
        /// </summary>
        ///
        /// <param name="options"> Update Session parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Session </returns> 
        public static async System.Threading.Tasks.Task<SessionResource> UpdateAsync(UpdateSessionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Update a specific Session.
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        /// <param name="pathSid"> A string that uniquely identifies this Session. </param>
        /// <param name="uniqueName"> A unique, developer assigned name of this Session. </param>
        /// <param name="ttl"> How long will this session stay open, in seconds. </param>
        /// <param name="status"> The Status of this Session </param>
        /// <param name="participants"> The participants </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Session </returns> 
        public static SessionResource Update(string pathServiceSid, string pathSid, string uniqueName = null, int? ttl = null, SessionResource.StatusEnum status = null, List<string> participants = null, ITwilioRestClient client = null)
        {
            var options = new UpdateSessionOptions(pathServiceSid, pathSid){UniqueName = uniqueName, Ttl = ttl, Status = status, Participants = participants};
            return Update(options, client);
        }

        #if !NET35
        /// <summary>
        /// Update a specific Session.
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        /// <param name="pathSid"> A string that uniquely identifies this Session. </param>
        /// <param name="uniqueName"> A unique, developer assigned name of this Session. </param>
        /// <param name="ttl"> How long will this session stay open, in seconds. </param>
        /// <param name="status"> The Status of this Session </param>
        /// <param name="participants"> The participants </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Session </returns> 
        public static async System.Threading.Tasks.Task<SessionResource> UpdateAsync(string pathServiceSid, string pathSid, string uniqueName = null, int? ttl = null, SessionResource.StatusEnum status = null, List<string> participants = null, ITwilioRestClient client = null)
        {
            var options = new UpdateSessionOptions(pathServiceSid, pathSid){UniqueName = uniqueName, Ttl = ttl, Status = status, Participants = participants};
            return await UpdateAsync(options, client);
        }
        #endif

        /// <summary>
        /// Converts a JSON string into a SessionResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> SessionResource object represented by the provided JSON </returns> 
        public static SessionResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<SessionResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// A string that uniquely identifies this Session.
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        /// <summary>
        /// Service Sid.
        /// </summary>
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }
        /// <summary>
        /// Account Sid.
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// A unique, developer assigned name of this Session.
        /// </summary>
        [JsonProperty("unique_name")]
        public string UniqueName { get; private set; }
        /// <summary>
        /// How long will this session stay open, in seconds.
        /// </summary>
        [JsonProperty("ttl")]
        public int? Ttl { get; private set; }
        /// <summary>
        /// The Status of this Session
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SessionResource.StatusEnum Status { get; private set; }
        /// <summary>
        /// The date this Session was started
        /// </summary>
        [JsonProperty("start_time")]
        public DateTime? StartTime { get; private set; }
        /// <summary>
        /// The date this Session was ended
        /// </summary>
        [JsonProperty("end_time")]
        public DateTime? EndTime { get; private set; }
        /// <summary>
        /// The date this Session was created
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        /// <summary>
        /// The date this Session was updated
        /// </summary>
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        /// <summary>
        /// The URL of this Session.
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }
        /// <summary>
        /// Nested resource URLs.
        /// </summary>
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }

        private SessionResource()
        {

        }
    }

}