using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Recording.AddOnResult 
{

    /// <summary>
    /// PayloadResource
    /// </summary>
    public class PayloadResource : Resource 
    {
        private static Request BuildFetchRequest(FetchPayloadOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/Recordings/" + options.PathReferenceSid + "/AddOnResults/" + options.PathAddOnResultSid + "/Payloads/" + options.PathSid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Fetch an instance of a result payload
        /// </summary>
        ///
        /// <param name="options"> Fetch Payload parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Payload </returns> 
        public static PayloadResource Fetch(FetchPayloadOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Fetch an instance of a result payload
        /// </summary>
        ///
        /// <param name="options"> Fetch Payload parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Payload </returns> 
        public static async System.Threading.Tasks.Task<PayloadResource> FetchAsync(FetchPayloadOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Fetch an instance of a result payload
        /// </summary>
        ///
        /// <param name="pathReferenceSid"> The reference_sid </param>
        /// <param name="pathAddOnResultSid"> The add_on_result_sid </param>
        /// <param name="pathSid"> Fetch by unique payload Sid </param>
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Payload </returns> 
        public static PayloadResource Fetch(string pathReferenceSid, string pathAddOnResultSid, string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchPayloadOptions(pathReferenceSid, pathAddOnResultSid, pathSid){PathAccountSid = pathAccountSid};
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// Fetch an instance of a result payload
        /// </summary>
        ///
        /// <param name="pathReferenceSid"> The reference_sid </param>
        /// <param name="pathAddOnResultSid"> The add_on_result_sid </param>
        /// <param name="pathSid"> Fetch by unique payload Sid </param>
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Payload </returns> 
        public static async System.Threading.Tasks.Task<PayloadResource> FetchAsync(string pathReferenceSid, string pathAddOnResultSid, string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchPayloadOptions(pathReferenceSid, pathAddOnResultSid, pathSid){PathAccountSid = pathAccountSid};
            return await FetchAsync(options, client);
        }
        #endif

        private static Request BuildReadRequest(ReadPayloadOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/Recordings/" + options.PathReferenceSid + "/AddOnResults/" + options.PathAddOnResultSid + "/Payloads.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Retrieve a list of payloads belonging to the Add-on result
        /// </summary>
        ///
        /// <param name="options"> Read Payload parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Payload </returns> 
        public static ResourceSet<PayloadResource> Read(ReadPayloadOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));

            var page = Page<PayloadResource>.FromJson("payloads", response.Content);
            return new ResourceSet<PayloadResource>(page, options, client);
        }

        #if !NET35
        /// <summary>
        /// Retrieve a list of payloads belonging to the Add-on result
        /// </summary>
        ///
        /// <param name="options"> Read Payload parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Payload </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<PayloadResource>> ReadAsync(ReadPayloadOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<PayloadResource>.FromJson("payloads", response.Content);
            return new ResourceSet<PayloadResource>(page, options, client);
        }
        #endif

        /// <summary>
        /// Retrieve a list of payloads belonging to the Add-on result
        /// </summary>
        ///
        /// <param name="pathReferenceSid"> The reference_sid </param>
        /// <param name="pathAddOnResultSid"> The add_on_result_sid </param>
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Payload </returns> 
        public static ResourceSet<PayloadResource> Read(string pathReferenceSid, string pathAddOnResultSid, string pathAccountSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadPayloadOptions(pathReferenceSid, pathAddOnResultSid){PathAccountSid = pathAccountSid, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary>
        /// Retrieve a list of payloads belonging to the Add-on result
        /// </summary>
        ///
        /// <param name="pathReferenceSid"> The reference_sid </param>
        /// <param name="pathAddOnResultSid"> The add_on_result_sid </param>
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Payload </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<PayloadResource>> ReadAsync(string pathReferenceSid, string pathAddOnResultSid, string pathAccountSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadPayloadOptions(pathReferenceSid, pathAddOnResultSid){PathAccountSid = pathAccountSid, PageSize = pageSize, Limit = limit};
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
        public static Page<PayloadResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<PayloadResource>.FromJson("payloads", response.Content);
        }

        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        ///
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns> 
        public static Page<PayloadResource> NextPage(Page<PayloadResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );

            var response = client.Request(request);
            return Page<PayloadResource>.FromJson("payloads", response.Content);
        }

        /// <summary>
        /// Fetch the previous page of records
        /// </summary>
        ///
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns> 
        public static Page<PayloadResource> PreviousPage(Page<PayloadResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );

            var response = client.Request(request);
            return Page<PayloadResource>.FromJson("payloads", response.Content);
        }

        private static Request BuildDeleteRequest(DeletePayloadOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/Recordings/" + options.PathReferenceSid + "/AddOnResults/" + options.PathAddOnResultSid + "/Payloads/" + options.PathSid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Delete a payload from the result along with all associated Data
        /// </summary>
        ///
        /// <param name="options"> Delete Payload parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Payload </returns> 
        public static bool Delete(DeletePayloadOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary>
        /// Delete a payload from the result along with all associated Data
        /// </summary>
        ///
        /// <param name="options"> Delete Payload parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Payload </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeletePayloadOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary>
        /// Delete a payload from the result along with all associated Data
        /// </summary>
        ///
        /// <param name="pathReferenceSid"> The reference_sid </param>
        /// <param name="pathAddOnResultSid"> The add_on_result_sid </param>
        /// <param name="pathSid"> Delete by unique payload Sid </param>
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Payload </returns> 
        public static bool Delete(string pathReferenceSid, string pathAddOnResultSid, string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeletePayloadOptions(pathReferenceSid, pathAddOnResultSid, pathSid){PathAccountSid = pathAccountSid};
            return Delete(options, client);
        }

        #if !NET35
        /// <summary>
        /// Delete a payload from the result along with all associated Data
        /// </summary>
        ///
        /// <param name="pathReferenceSid"> The reference_sid </param>
        /// <param name="pathAddOnResultSid"> The add_on_result_sid </param>
        /// <param name="pathSid"> Delete by unique payload Sid </param>
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Payload </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathReferenceSid, string pathAddOnResultSid, string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeletePayloadOptions(pathReferenceSid, pathAddOnResultSid, pathSid){PathAccountSid = pathAccountSid};
            return await DeleteAsync(options, client);
        }
        #endif

        /// <summary>
        /// Converts a JSON string into a PayloadResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> PayloadResource object represented by the provided JSON </returns> 
        public static PayloadResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<PayloadResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// A string that uniquely identifies this payload
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        /// <summary>
        /// A string that uniquely identifies the result
        /// </summary>
        [JsonProperty("add_on_result_sid")]
        public string AddOnResultSid { get; private set; }
        /// <summary>
        /// The unique sid that identifies this account
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// A string that describes the payload.
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; private set; }
        /// <summary>
        /// A string that uniquely identifies the Add-on.
        /// </summary>
        [JsonProperty("add_on_sid")]
        public string AddOnSid { get; private set; }
        /// <summary>
        /// A string that uniquely identifies the Add-on configuration.
        /// </summary>
        [JsonProperty("add_on_configuration_sid")]
        public string AddOnConfigurationSid { get; private set; }
        /// <summary>
        /// The MIME type of the payload.
        /// </summary>
        [JsonProperty("content_type")]
        public string ContentType { get; private set; }
        /// <summary>
        /// The date this resource was created
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        /// <summary>
        /// The date this resource was last updated
        /// </summary>
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        /// <summary>
        /// A string that uniquely identifies the recording.
        /// </summary>
        [JsonProperty("reference_sid")]
        public string ReferenceSid { get; private set; }
        /// <summary>
        /// The subresource_uris
        /// </summary>
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> SubresourceUris { get; private set; }

        private PayloadResource()
        {

        }
    }

}