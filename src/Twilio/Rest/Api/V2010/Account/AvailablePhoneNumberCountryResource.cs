using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account 
{

    /// <summary>
    /// AvailablePhoneNumberCountryResource
    /// </summary>
    public class AvailablePhoneNumberCountryResource : Resource 
    {
        private static Request BuildReadRequest(ReadAvailablePhoneNumberCountryOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/AvailablePhoneNumbers.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="options"> Read AvailablePhoneNumberCountry parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of AvailablePhoneNumberCountry </returns> 
        public static ResourceSet<AvailablePhoneNumberCountryResource> Read(ReadAvailablePhoneNumberCountryOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));

            var page = Page<AvailablePhoneNumberCountryResource>.FromJson("countries", response.Content);
            return new ResourceSet<AvailablePhoneNumberCountryResource>(page, options, client);
        }

        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="options"> Read AvailablePhoneNumberCountry parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of AvailablePhoneNumberCountry </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<AvailablePhoneNumberCountryResource>> ReadAsync(ReadAvailablePhoneNumberCountryOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<AvailablePhoneNumberCountryResource>.FromJson("countries", response.Content);
            return new ResourceSet<AvailablePhoneNumberCountryResource>(page, options, client);
        }
        #endif

        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of AvailablePhoneNumberCountry </returns> 
        public static ResourceSet<AvailablePhoneNumberCountryResource> Read(string pathAccountSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadAvailablePhoneNumberCountryOptions{PathAccountSid = pathAccountSid, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of AvailablePhoneNumberCountry </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<AvailablePhoneNumberCountryResource>> ReadAsync(string pathAccountSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadAvailablePhoneNumberCountryOptions{PathAccountSid = pathAccountSid, PageSize = pageSize, Limit = limit};
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
        public static Page<AvailablePhoneNumberCountryResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<AvailablePhoneNumberCountryResource>.FromJson("countries", response.Content);
        }

        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        ///
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns> 
        public static Page<AvailablePhoneNumberCountryResource> NextPage(Page<AvailablePhoneNumberCountryResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );

            var response = client.Request(request);
            return Page<AvailablePhoneNumberCountryResource>.FromJson("countries", response.Content);
        }

        /// <summary>
        /// Fetch the previous page of records
        /// </summary>
        ///
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns> 
        public static Page<AvailablePhoneNumberCountryResource> PreviousPage(Page<AvailablePhoneNumberCountryResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );

            var response = client.Request(request);
            return Page<AvailablePhoneNumberCountryResource>.FromJson("countries", response.Content);
        }

        private static Request BuildFetchRequest(FetchAvailablePhoneNumberCountryOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/AvailablePhoneNumbers/" + options.PathCountryCode + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="options"> Fetch AvailablePhoneNumberCountry parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of AvailablePhoneNumberCountry </returns> 
        public static AvailablePhoneNumberCountryResource Fetch(FetchAvailablePhoneNumberCountryOptions options, ITwilioRestClient client = null)
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
        /// <param name="options"> Fetch AvailablePhoneNumberCountry parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of AvailablePhoneNumberCountry </returns> 
        public static async System.Threading.Tasks.Task<AvailablePhoneNumberCountryResource> FetchAsync(FetchAvailablePhoneNumberCountryOptions options, ITwilioRestClient client = null)
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
        /// <param name="pathCountryCode"> The country_code </param>
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of AvailablePhoneNumberCountry </returns> 
        public static AvailablePhoneNumberCountryResource Fetch(string pathCountryCode, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchAvailablePhoneNumberCountryOptions(pathCountryCode){PathAccountSid = pathAccountSid};
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="pathCountryCode"> The country_code </param>
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of AvailablePhoneNumberCountry </returns> 
        public static async System.Threading.Tasks.Task<AvailablePhoneNumberCountryResource> FetchAsync(string pathCountryCode, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchAvailablePhoneNumberCountryOptions(pathCountryCode){PathAccountSid = pathAccountSid};
            return await FetchAsync(options, client);
        }
        #endif

        /// <summary>
        /// Converts a JSON string into a AvailablePhoneNumberCountryResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> AvailablePhoneNumberCountryResource object represented by the provided JSON </returns> 
        public static AvailablePhoneNumberCountryResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<AvailablePhoneNumberCountryResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// The ISO Country code to lookup phone numbers for.
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; private set; }
        /// <summary>
        /// The country
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; private set; }
        /// <summary>
        /// The uri
        /// </summary>
        [JsonProperty("uri")]
        public Uri Uri { get; private set; }
        /// <summary>
        /// The beta
        /// </summary>
        [JsonProperty("beta")]
        public bool? Beta { get; private set; }
        /// <summary>
        /// The subresource_uris
        /// </summary>
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> SubresourceUris { get; private set; }

        private AvailablePhoneNumberCountryResource()
        {

        }
    }

}