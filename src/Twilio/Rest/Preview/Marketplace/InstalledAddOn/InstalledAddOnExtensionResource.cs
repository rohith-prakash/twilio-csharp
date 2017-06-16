using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Marketplace.InstalledAddOn 
{

    /// <summary>
    /// InstalledAddOnExtensionResource
    /// </summary>
    public class InstalledAddOnExtensionResource : Resource 
    {
        private static Request BuildFetchRequest(FetchInstalledAddOnExtensionOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/marketplace/InstalledAddOns/" + options.PathInstalledAddOnSid + "/Extensions/" + options.PathSid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Fetch an instance of an Extension for the Installed Add-on.
        /// </summary>
        ///
        /// <param name="options"> Fetch InstalledAddOnExtension parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of InstalledAddOnExtension </returns> 
        public static InstalledAddOnExtensionResource Fetch(FetchInstalledAddOnExtensionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Fetch an instance of an Extension for the Installed Add-on.
        /// </summary>
        ///
        /// <param name="options"> Fetch InstalledAddOnExtension parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of InstalledAddOnExtension </returns> 
        public static async System.Threading.Tasks.Task<InstalledAddOnExtensionResource> FetchAsync(FetchInstalledAddOnExtensionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Fetch an instance of an Extension for the Installed Add-on.
        /// </summary>
        ///
        /// <param name="pathInstalledAddOnSid"> The installed_add_on_sid </param>
        /// <param name="pathSid"> The unique Extension Sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of InstalledAddOnExtension </returns> 
        public static InstalledAddOnExtensionResource Fetch(string pathInstalledAddOnSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchInstalledAddOnExtensionOptions(pathInstalledAddOnSid, pathSid);
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// Fetch an instance of an Extension for the Installed Add-on.
        /// </summary>
        ///
        /// <param name="pathInstalledAddOnSid"> The installed_add_on_sid </param>
        /// <param name="pathSid"> The unique Extension Sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of InstalledAddOnExtension </returns> 
        public static async System.Threading.Tasks.Task<InstalledAddOnExtensionResource> FetchAsync(string pathInstalledAddOnSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchInstalledAddOnExtensionOptions(pathInstalledAddOnSid, pathSid);
            return await FetchAsync(options, client);
        }
        #endif

        private static Request BuildUpdateRequest(UpdateInstalledAddOnExtensionOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                "/marketplace/InstalledAddOns/" + options.PathInstalledAddOnSid + "/Extensions/" + options.PathSid + "",
                client.Region,
                postParams: options.GetParams()
            );
        }

        /// <summary>
        /// Update an Extension for an Add-on installation.
        /// </summary>
        ///
        /// <param name="options"> Update InstalledAddOnExtension parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of InstalledAddOnExtension </returns> 
        public static InstalledAddOnExtensionResource Update(UpdateInstalledAddOnExtensionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Update an Extension for an Add-on installation.
        /// </summary>
        ///
        /// <param name="options"> Update InstalledAddOnExtension parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of InstalledAddOnExtension </returns> 
        public static async System.Threading.Tasks.Task<InstalledAddOnExtensionResource> UpdateAsync(UpdateInstalledAddOnExtensionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Update an Extension for an Add-on installation.
        /// </summary>
        ///
        /// <param name="pathInstalledAddOnSid"> The installed_add_on_sid </param>
        /// <param name="pathSid"> The sid </param>
        /// <param name="enabled"> A Boolean indicating if the Extension will be invoked </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of InstalledAddOnExtension </returns> 
        public static InstalledAddOnExtensionResource Update(string pathInstalledAddOnSid, string pathSid, bool? enabled, ITwilioRestClient client = null)
        {
            var options = new UpdateInstalledAddOnExtensionOptions(pathInstalledAddOnSid, pathSid, enabled);
            return Update(options, client);
        }

        #if !NET35
        /// <summary>
        /// Update an Extension for an Add-on installation.
        /// </summary>
        ///
        /// <param name="pathInstalledAddOnSid"> The installed_add_on_sid </param>
        /// <param name="pathSid"> The sid </param>
        /// <param name="enabled"> A Boolean indicating if the Extension will be invoked </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of InstalledAddOnExtension </returns> 
        public static async System.Threading.Tasks.Task<InstalledAddOnExtensionResource> UpdateAsync(string pathInstalledAddOnSid, string pathSid, bool? enabled, ITwilioRestClient client = null)
        {
            var options = new UpdateInstalledAddOnExtensionOptions(pathInstalledAddOnSid, pathSid, enabled);
            return await UpdateAsync(options, client);
        }
        #endif

        private static Request BuildReadRequest(ReadInstalledAddOnExtensionOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/marketplace/InstalledAddOns/" + options.PathInstalledAddOnSid + "/Extensions",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Retrieve a list of Extensions for the Installed Add-on.
        /// </summary>
        ///
        /// <param name="options"> Read InstalledAddOnExtension parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of InstalledAddOnExtension </returns> 
        public static ResourceSet<InstalledAddOnExtensionResource> Read(ReadInstalledAddOnExtensionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));

            var page = Page<InstalledAddOnExtensionResource>.FromJson("extensions", response.Content);
            return new ResourceSet<InstalledAddOnExtensionResource>(page, options, client);
        }

        #if !NET35
        /// <summary>
        /// Retrieve a list of Extensions for the Installed Add-on.
        /// </summary>
        ///
        /// <param name="options"> Read InstalledAddOnExtension parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of InstalledAddOnExtension </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<InstalledAddOnExtensionResource>> ReadAsync(ReadInstalledAddOnExtensionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<InstalledAddOnExtensionResource>.FromJson("extensions", response.Content);
            return new ResourceSet<InstalledAddOnExtensionResource>(page, options, client);
        }
        #endif

        /// <summary>
        /// Retrieve a list of Extensions for the Installed Add-on.
        /// </summary>
        ///
        /// <param name="pathInstalledAddOnSid"> The installed_add_on_sid </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of InstalledAddOnExtension </returns> 
        public static ResourceSet<InstalledAddOnExtensionResource> Read(string pathInstalledAddOnSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadInstalledAddOnExtensionOptions(pathInstalledAddOnSid){PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary>
        /// Retrieve a list of Extensions for the Installed Add-on.
        /// </summary>
        ///
        /// <param name="pathInstalledAddOnSid"> The installed_add_on_sid </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of InstalledAddOnExtension </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<InstalledAddOnExtensionResource>> ReadAsync(string pathInstalledAddOnSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadInstalledAddOnExtensionOptions(pathInstalledAddOnSid){PageSize = pageSize, Limit = limit};
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
        public static Page<InstalledAddOnExtensionResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<InstalledAddOnExtensionResource>.FromJson("extensions", response.Content);
        }

        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        ///
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns> 
        public static Page<InstalledAddOnExtensionResource> NextPage(Page<InstalledAddOnExtensionResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Preview,
                    client.Region
                )
            );

            var response = client.Request(request);
            return Page<InstalledAddOnExtensionResource>.FromJson("extensions", response.Content);
        }

        /// <summary>
        /// Fetch the previous page of records
        /// </summary>
        ///
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns> 
        public static Page<InstalledAddOnExtensionResource> PreviousPage(Page<InstalledAddOnExtensionResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(
                    Rest.Domain.Preview,
                    client.Region
                )
            );

            var response = client.Request(request);
            return Page<InstalledAddOnExtensionResource>.FromJson("extensions", response.Content);
        }

        /// <summary>
        /// Converts a JSON string into a InstalledAddOnExtensionResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> InstalledAddOnExtensionResource object represented by the provided JSON </returns> 
        public static InstalledAddOnExtensionResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<InstalledAddOnExtensionResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// A string that uniquely identifies this Extension
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        /// <summary>
        /// The installed_add_on_sid
        /// </summary>
        [JsonProperty("installed_add_on_sid")]
        public string InstalledAddOnSid { get; private set; }
        /// <summary>
        /// A human-readable description of this Extension
        /// </summary>
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        /// <summary>
        /// A human-readable description of the Extension's Product
        /// </summary>
        [JsonProperty("product_name")]
        public string ProductName { get; private set; }
        /// <summary>
        /// The string that uniquely identifies this Extension
        /// </summary>
        [JsonProperty("unique_name")]
        public string UniqueName { get; private set; }
        /// <summary>
        /// A Boolean indicating if the Extension will be invoked
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; private set; }
        /// <summary>
        /// The url
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        private InstalledAddOnExtensionResource()
        {

        }
    }

}