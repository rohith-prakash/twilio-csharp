using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Notify.V1.Service 
{

    /// <summary>
    /// UserResource
    /// </summary>
    public class UserResource : Resource 
    {
        private static Request BuildCreateRequest(CreateUserOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Notify,
                "/v1/Services/" + options.PathServiceSid + "/Users",
                client.Region,
                postParams: options.GetParams()
            );
        }

        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="options"> Create User parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of User </returns> 
        public static UserResource Create(CreateUserOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="options"> Create User parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of User </returns> 
        public static async System.Threading.Tasks.Task<UserResource> CreateAsync(CreateUserOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="identity"> The identity </param>
        /// <param name="segment"> The segment </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of User </returns> 
        public static UserResource Create(string pathServiceSid, string identity, List<string> segment = null, ITwilioRestClient client = null)
        {
            var options = new CreateUserOptions(pathServiceSid, identity){Segment = segment};
            return Create(options, client);
        }

        #if !NET35
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="identity"> The identity </param>
        /// <param name="segment"> The segment </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of User </returns> 
        public static async System.Threading.Tasks.Task<UserResource> CreateAsync(string pathServiceSid, string identity, List<string> segment = null, ITwilioRestClient client = null)
        {
            var options = new CreateUserOptions(pathServiceSid, identity){Segment = segment};
            return await CreateAsync(options, client);
        }
        #endif

        private static Request BuildDeleteRequest(DeleteUserOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Notify,
                "/v1/Services/" + options.PathServiceSid + "/Users/" + options.PathIdentity + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="options"> Delete User parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of User </returns> 
        public static bool Delete(DeleteUserOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="options"> Delete User parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of User </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteUserOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pathIdentity"> The identity </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of User </returns> 
        public static bool Delete(string pathServiceSid, string pathIdentity, ITwilioRestClient client = null)
        {
            var options = new DeleteUserOptions(pathServiceSid, pathIdentity);
            return Delete(options, client);
        }

        #if !NET35
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pathIdentity"> The identity </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of User </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathServiceSid, string pathIdentity, ITwilioRestClient client = null)
        {
            var options = new DeleteUserOptions(pathServiceSid, pathIdentity);
            return await DeleteAsync(options, client);
        }
        #endif

        private static Request BuildFetchRequest(FetchUserOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Notify,
                "/v1/Services/" + options.PathServiceSid + "/Users/" + options.PathIdentity + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="options"> Fetch User parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of User </returns> 
        public static UserResource Fetch(FetchUserOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="options"> Fetch User parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of User </returns> 
        public static async System.Threading.Tasks.Task<UserResource> FetchAsync(FetchUserOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pathIdentity"> The identity </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of User </returns> 
        public static UserResource Fetch(string pathServiceSid, string pathIdentity, ITwilioRestClient client = null)
        {
            var options = new FetchUserOptions(pathServiceSid, pathIdentity);
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pathIdentity"> The identity </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of User </returns> 
        public static async System.Threading.Tasks.Task<UserResource> FetchAsync(string pathServiceSid, string pathIdentity, ITwilioRestClient client = null)
        {
            var options = new FetchUserOptions(pathServiceSid, pathIdentity);
            return await FetchAsync(options, client);
        }
        #endif

        private static Request BuildReadRequest(ReadUserOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Notify,
                "/v1/Services/" + options.PathServiceSid + "/Users",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="options"> Read User parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of User </returns> 
        public static ResourceSet<UserResource> Read(ReadUserOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));

            var page = Page<UserResource>.FromJson("users", response.Content);
            return new ResourceSet<UserResource>(page, options, client);
        }

        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="options"> Read User parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of User </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<UserResource>> ReadAsync(ReadUserOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<UserResource>.FromJson("users", response.Content);
            return new ResourceSet<UserResource>(page, options, client);
        }
        #endif

        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="identity"> The identity </param>
        /// <param name="segment"> The segment </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of User </returns> 
        public static ResourceSet<UserResource> Read(string pathServiceSid, List<string> identity = null, string segment = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadUserOptions(pathServiceSid){Identity = identity, Segment = segment, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="identity"> The identity </param>
        /// <param name="segment"> The segment </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of User </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<UserResource>> ReadAsync(string pathServiceSid, List<string> identity = null, string segment = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadUserOptions(pathServiceSid){Identity = identity, Segment = segment, PageSize = pageSize, Limit = limit};
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
        public static Page<UserResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<UserResource>.FromJson("users", response.Content);
        }

        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        ///
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns> 
        public static Page<UserResource> NextPage(Page<UserResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Notify,
                    client.Region
                )
            );

            var response = client.Request(request);
            return Page<UserResource>.FromJson("users", response.Content);
        }

        /// <summary>
        /// Fetch the previous page of records
        /// </summary>
        ///
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns> 
        public static Page<UserResource> PreviousPage(Page<UserResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(
                    Rest.Domain.Notify,
                    client.Region
                )
            );

            var response = client.Request(request);
            return Page<UserResource>.FromJson("users", response.Content);
        }

        /// <summary>
        /// Converts a JSON string into a UserResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> UserResource object represented by the provided JSON </returns> 
        public static UserResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<UserResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// The sid
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        /// <summary>
        /// The account_sid
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// The service_sid
        /// </summary>
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }
        /// <summary>
        /// The identity
        /// </summary>
        [JsonProperty("identity")]
        public string Identity { get; private set; }
        /// <summary>
        /// The date_created
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        /// <summary>
        /// The date_updated
        /// </summary>
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        /// <summary>
        /// The segments
        /// </summary>
        [JsonProperty("segments")]
        public List<string> Segments { get; private set; }
        /// <summary>
        /// The url
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }
        /// <summary>
        /// The links
        /// </summary>
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }

        private UserResource()
        {

        }
    }

}