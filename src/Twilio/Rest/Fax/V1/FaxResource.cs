using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Fax.V1 
{

    /// <summary>
    /// FaxResource
    /// </summary>
    public class FaxResource : Resource 
    {
        public sealed class DirectionEnum : StringEnum 
        {
            private DirectionEnum(string value) : base(value) {}
            public DirectionEnum() {}

            public static readonly DirectionEnum Inbound = new DirectionEnum("inbound");
            public static readonly DirectionEnum Outbound = new DirectionEnum("outbound");
        }

        public sealed class QualityEnum : StringEnum 
        {
            private QualityEnum(string value) : base(value) {}
            public QualityEnum() {}

            public static readonly QualityEnum Standard = new QualityEnum("standard");
            public static readonly QualityEnum Fine = new QualityEnum("fine");
            public static readonly QualityEnum Superfine = new QualityEnum("superfine");
        }

        public sealed class StatusEnum : StringEnum 
        {
            private StatusEnum(string value) : base(value) {}
            public StatusEnum() {}

            public static readonly StatusEnum Queued = new StatusEnum("queued");
            public static readonly StatusEnum Processing = new StatusEnum("processing");
            public static readonly StatusEnum Sending = new StatusEnum("sending");
            public static readonly StatusEnum Delivered = new StatusEnum("delivered");
            public static readonly StatusEnum Receiving = new StatusEnum("receiving");
            public static readonly StatusEnum Received = new StatusEnum("received");
            public static readonly StatusEnum NoAnswer = new StatusEnum("no-answer");
            public static readonly StatusEnum Busy = new StatusEnum("busy");
            public static readonly StatusEnum Failed = new StatusEnum("failed");
            public static readonly StatusEnum Canceled = new StatusEnum("canceled");
        }

        public sealed class UpdateStatusEnum : StringEnum 
        {
            private UpdateStatusEnum(string value) : base(value) {}
            public UpdateStatusEnum() {}

            public static readonly UpdateStatusEnum Canceled = new UpdateStatusEnum("canceled");
        }

        private static Request BuildFetchRequest(FetchFaxOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Fax,
                "/v1/Faxes/" + options.PathSid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Fetch a specific fax.
        /// </summary>
        ///
        /// <param name="options"> Fetch Fax parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Fax </returns> 
        public static FaxResource Fetch(FetchFaxOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Fetch a specific fax.
        /// </summary>
        ///
        /// <param name="options"> Fetch Fax parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Fax </returns> 
        public static async System.Threading.Tasks.Task<FaxResource> FetchAsync(FetchFaxOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Fetch a specific fax.
        /// </summary>
        ///
        /// <param name="pathSid"> A string that uniquely identifies this fax. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Fax </returns> 
        public static FaxResource Fetch(string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchFaxOptions(pathSid);
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// Fetch a specific fax.
        /// </summary>
        ///
        /// <param name="pathSid"> A string that uniquely identifies this fax. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Fax </returns> 
        public static async System.Threading.Tasks.Task<FaxResource> FetchAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchFaxOptions(pathSid);
            return await FetchAsync(options, client);
        }
        #endif

        private static Request BuildReadRequest(ReadFaxOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Fax,
                "/v1/Faxes",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Retrieve a list of all faxes.
        /// </summary>
        ///
        /// <param name="options"> Read Fax parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Fax </returns> 
        public static ResourceSet<FaxResource> Read(ReadFaxOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));

            var page = Page<FaxResource>.FromJson("faxes", response.Content);
            return new ResourceSet<FaxResource>(page, options, client);
        }

        #if !NET35
        /// <summary>
        /// Retrieve a list of all faxes.
        /// </summary>
        ///
        /// <param name="options"> Read Fax parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Fax </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<FaxResource>> ReadAsync(ReadFaxOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<FaxResource>.FromJson("faxes", response.Content);
            return new ResourceSet<FaxResource>(page, options, client);
        }
        #endif

        /// <summary>
        /// Retrieve a list of all faxes.
        /// </summary>
        ///
        /// <param name="from"> Include only faxes sent from </param>
        /// <param name="to"> Include only faxes sent to </param>
        /// <param name="dateCreatedOnOrBefore"> Include only faxes created on or before </param>
        /// <param name="dateCreatedAfter"> Include only faxes created after </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Fax </returns> 
        public static ResourceSet<FaxResource> Read(string from = null, string to = null, DateTime? dateCreatedOnOrBefore = null, DateTime? dateCreatedAfter = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadFaxOptions{From = from, To = to, DateCreatedOnOrBefore = dateCreatedOnOrBefore, DateCreatedAfter = dateCreatedAfter, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary>
        /// Retrieve a list of all faxes.
        /// </summary>
        ///
        /// <param name="from"> Include only faxes sent from </param>
        /// <param name="to"> Include only faxes sent to </param>
        /// <param name="dateCreatedOnOrBefore"> Include only faxes created on or before </param>
        /// <param name="dateCreatedAfter"> Include only faxes created after </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Fax </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<FaxResource>> ReadAsync(string from = null, string to = null, DateTime? dateCreatedOnOrBefore = null, DateTime? dateCreatedAfter = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadFaxOptions{From = from, To = to, DateCreatedOnOrBefore = dateCreatedOnOrBefore, DateCreatedAfter = dateCreatedAfter, PageSize = pageSize, Limit = limit};
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
        public static Page<FaxResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<FaxResource>.FromJson("faxes", response.Content);
        }

        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        ///
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns> 
        public static Page<FaxResource> NextPage(Page<FaxResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Fax,
                    client.Region
                )
            );

            var response = client.Request(request);
            return Page<FaxResource>.FromJson("faxes", response.Content);
        }

        /// <summary>
        /// Fetch the previous page of records
        /// </summary>
        ///
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns> 
        public static Page<FaxResource> PreviousPage(Page<FaxResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(
                    Rest.Domain.Fax,
                    client.Region
                )
            );

            var response = client.Request(request);
            return Page<FaxResource>.FromJson("faxes", response.Content);
        }

        private static Request BuildCreateRequest(CreateFaxOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Fax,
                "/v1/Faxes",
                client.Region,
                postParams: options.GetParams()
            );
        }

        /// <summary>
        /// Create a new fax to send to a phone number or SIP endpoint
        /// </summary>
        ///
        /// <param name="options"> Create Fax parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Fax </returns> 
        public static FaxResource Create(CreateFaxOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Create a new fax to send to a phone number or SIP endpoint
        /// </summary>
        ///
        /// <param name="options"> Create Fax parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Fax </returns> 
        public static async System.Threading.Tasks.Task<FaxResource> CreateAsync(CreateFaxOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Create a new fax to send to a phone number or SIP endpoint
        /// </summary>
        ///
        /// <param name="to"> The phone number or SIP address to send the fax to </param>
        /// <param name="mediaUrl"> URL that points to the fax media </param>
        /// <param name="quality"> The quality of this fax </param>
        /// <param name="statusCallback"> URL for fax status callbacks </param>
        /// <param name="from"> Twilio number from which to originate the fax </param>
        /// <param name="sipAuthUsername"> Username for SIP authentication </param>
        /// <param name="sipAuthPassword"> Password for SIP authentication </param>
        /// <param name="storeMedia"> Whether or not to store media </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Fax </returns> 
        public static FaxResource Create(string to, Uri mediaUrl, FaxResource.QualityEnum quality = null, Uri statusCallback = null, string from = null, string sipAuthUsername = null, string sipAuthPassword = null, bool? storeMedia = null, ITwilioRestClient client = null)
        {
            var options = new CreateFaxOptions(to, mediaUrl){Quality = quality, StatusCallback = statusCallback, From = from, SipAuthUsername = sipAuthUsername, SipAuthPassword = sipAuthPassword, StoreMedia = storeMedia};
            return Create(options, client);
        }

        #if !NET35
        /// <summary>
        /// Create a new fax to send to a phone number or SIP endpoint
        /// </summary>
        ///
        /// <param name="to"> The phone number or SIP address to send the fax to </param>
        /// <param name="mediaUrl"> URL that points to the fax media </param>
        /// <param name="quality"> The quality of this fax </param>
        /// <param name="statusCallback"> URL for fax status callbacks </param>
        /// <param name="from"> Twilio number from which to originate the fax </param>
        /// <param name="sipAuthUsername"> Username for SIP authentication </param>
        /// <param name="sipAuthPassword"> Password for SIP authentication </param>
        /// <param name="storeMedia"> Whether or not to store media </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Fax </returns> 
        public static async System.Threading.Tasks.Task<FaxResource> CreateAsync(string to, Uri mediaUrl, FaxResource.QualityEnum quality = null, Uri statusCallback = null, string from = null, string sipAuthUsername = null, string sipAuthPassword = null, bool? storeMedia = null, ITwilioRestClient client = null)
        {
            var options = new CreateFaxOptions(to, mediaUrl){Quality = quality, StatusCallback = statusCallback, From = from, SipAuthUsername = sipAuthUsername, SipAuthPassword = sipAuthPassword, StoreMedia = storeMedia};
            return await CreateAsync(options, client);
        }
        #endif

        private static Request BuildUpdateRequest(UpdateFaxOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Fax,
                "/v1/Faxes/" + options.PathSid + "",
                client.Region,
                postParams: options.GetParams()
            );
        }

        /// <summary>
        /// Update a specific fax.
        /// </summary>
        ///
        /// <param name="options"> Update Fax parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Fax </returns> 
        public static FaxResource Update(UpdateFaxOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Update a specific fax.
        /// </summary>
        ///
        /// <param name="options"> Update Fax parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Fax </returns> 
        public static async System.Threading.Tasks.Task<FaxResource> UpdateAsync(UpdateFaxOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Update a specific fax.
        /// </summary>
        ///
        /// <param name="pathSid"> A string that uniquely identifies this fax. </param>
        /// <param name="status"> The updated status of this fax </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Fax </returns> 
        public static FaxResource Update(string pathSid, FaxResource.UpdateStatusEnum status = null, ITwilioRestClient client = null)
        {
            var options = new UpdateFaxOptions(pathSid){Status = status};
            return Update(options, client);
        }

        #if !NET35
        /// <summary>
        /// Update a specific fax.
        /// </summary>
        ///
        /// <param name="pathSid"> A string that uniquely identifies this fax. </param>
        /// <param name="status"> The updated status of this fax </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Fax </returns> 
        public static async System.Threading.Tasks.Task<FaxResource> UpdateAsync(string pathSid, FaxResource.UpdateStatusEnum status = null, ITwilioRestClient client = null)
        {
            var options = new UpdateFaxOptions(pathSid){Status = status};
            return await UpdateAsync(options, client);
        }
        #endif

        private static Request BuildDeleteRequest(DeleteFaxOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Fax,
                "/v1/Faxes/" + options.PathSid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Delete a specific fax and its associated media.
        /// </summary>
        ///
        /// <param name="options"> Delete Fax parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Fax </returns> 
        public static bool Delete(DeleteFaxOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary>
        /// Delete a specific fax and its associated media.
        /// </summary>
        ///
        /// <param name="options"> Delete Fax parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Fax </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteFaxOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary>
        /// Delete a specific fax and its associated media.
        /// </summary>
        ///
        /// <param name="pathSid"> A string that uniquely identifies this fax. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Fax </returns> 
        public static bool Delete(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteFaxOptions(pathSid);
            return Delete(options, client);
        }

        #if !NET35
        /// <summary>
        /// Delete a specific fax and its associated media.
        /// </summary>
        ///
        /// <param name="pathSid"> A string that uniquely identifies this fax. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Fax </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteFaxOptions(pathSid);
            return await DeleteAsync(options, client);
        }
        #endif

        /// <summary>
        /// Converts a JSON string into a FaxResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> FaxResource object represented by the provided JSON </returns> 
        public static FaxResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<FaxResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// A string that uniquely identifies this fax.
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        /// <summary>
        /// Account SID
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// The party that sent the fax
        /// </summary>
        [JsonProperty("from")]
        public string From { get; private set; }
        /// <summary>
        /// The party that received the fax
        /// </summary>
        [JsonProperty("to")]
        public string To { get; private set; }
        /// <summary>
        /// The quality of this fax
        /// </summary>
        [JsonProperty("quality")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FaxResource.QualityEnum Quality { get; private set; }
        /// <summary>
        /// Media SID
        /// </summary>
        [JsonProperty("media_sid")]
        public string MediaSid { get; private set; }
        /// <summary>
        /// URL pointing to fax media
        /// </summary>
        [JsonProperty("media_url")]
        public string MediaUrl { get; private set; }
        /// <summary>
        /// Number of pages
        /// </summary>
        [JsonProperty("num_pages")]
        public int? NumPages { get; private set; }
        /// <summary>
        /// The time taken to transmit the fax
        /// </summary>
        [JsonProperty("duration")]
        public int? Duration { get; private set; }
        /// <summary>
        /// The status of this fax
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FaxResource.StatusEnum Status { get; private set; }
        /// <summary>
        /// The direction of this fax
        /// </summary>
        [JsonProperty("direction")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FaxResource.DirectionEnum Direction { get; private set; }
        /// <summary>
        /// The API version used
        /// </summary>
        [JsonProperty("api_version")]
        public string ApiVersion { get; private set; }
        /// <summary>
        /// Fax transmission price
        /// </summary>
        [JsonProperty("price")]
        public decimal? Price { get; private set; }
        /// <summary>
        /// Currency used for billing
        /// </summary>
        [JsonProperty("price_unit")]
        public string PriceUnit { get; private set; }
        /// <summary>
        /// The date this fax was created
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        /// <summary>
        /// The date this fax was updated
        /// </summary>
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        /// <summary>
        /// Nested resource URLs
        /// </summary>
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }
        /// <summary>
        /// The URL of this resource
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        private FaxResource()
        {

        }
    }

}