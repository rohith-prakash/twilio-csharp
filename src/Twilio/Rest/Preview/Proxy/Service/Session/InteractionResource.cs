using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Preview.Proxy.Service.Session 
{

    /// <summary>
    /// InteractionResource
    /// </summary>
    public class InteractionResource : Resource 
    {
        public sealed class StatusEnum : StringEnum 
        {
            private StatusEnum(string value) : base(value) {}
            public StatusEnum() {}

            public static readonly StatusEnum Completed = new StatusEnum("completed");
            public static readonly StatusEnum InProgress = new StatusEnum("in-progress");
            public static readonly StatusEnum Failed = new StatusEnum("failed");
        }

        public sealed class ResourceStatusEnum : StringEnum 
        {
            private ResourceStatusEnum(string value) : base(value) {}
            public ResourceStatusEnum() {}

            public static readonly ResourceStatusEnum Queued = new ResourceStatusEnum("queued");
            public static readonly ResourceStatusEnum Sending = new ResourceStatusEnum("sending");
            public static readonly ResourceStatusEnum Sent = new ResourceStatusEnum("sent");
            public static readonly ResourceStatusEnum Failed = new ResourceStatusEnum("failed");
            public static readonly ResourceStatusEnum Delivered = new ResourceStatusEnum("delivered");
            public static readonly ResourceStatusEnum Undelivered = new ResourceStatusEnum("undelivered");
        }

        private static Request BuildFetchRequest(FetchInteractionOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/Proxy/Services/" + options.PathServiceSid + "/Sessions/" + options.PathSessionSid + "/Interactions/" + options.PathSid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Fetch a specific Interaction.
        /// </summary>
        ///
        /// <param name="options"> Fetch Interaction parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Interaction </returns> 
        public static InteractionResource Fetch(FetchInteractionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Fetch a specific Interaction.
        /// </summary>
        ///
        /// <param name="options"> Fetch Interaction parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Interaction </returns> 
        public static async System.Threading.Tasks.Task<InteractionResource> FetchAsync(FetchInteractionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Fetch a specific Interaction.
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        /// <param name="pathSessionSid"> Session Sid. </param>
        /// <param name="pathSid"> A string that uniquely identifies this Interaction. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Interaction </returns> 
        public static InteractionResource Fetch(string pathServiceSid, string pathSessionSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchInteractionOptions(pathServiceSid, pathSessionSid, pathSid);
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// Fetch a specific Interaction.
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        /// <param name="pathSessionSid"> Session Sid. </param>
        /// <param name="pathSid"> A string that uniquely identifies this Interaction. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Interaction </returns> 
        public static async System.Threading.Tasks.Task<InteractionResource> FetchAsync(string pathServiceSid, string pathSessionSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchInteractionOptions(pathServiceSid, pathSessionSid, pathSid);
            return await FetchAsync(options, client);
        }
        #endif

        private static Request BuildReadRequest(ReadInteractionOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/Proxy/Services/" + options.PathServiceSid + "/Sessions/" + options.PathSessionSid + "/Interactions",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Retrieve a list of all Interactions for a Session.
        /// </summary>
        ///
        /// <param name="options"> Read Interaction parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Interaction </returns> 
        public static ResourceSet<InteractionResource> Read(ReadInteractionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));

            var page = Page<InteractionResource>.FromJson("interactions", response.Content);
            return new ResourceSet<InteractionResource>(page, options, client);
        }

        #if !NET35
        /// <summary>
        /// Retrieve a list of all Interactions for a Session.
        /// </summary>
        ///
        /// <param name="options"> Read Interaction parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Interaction </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<InteractionResource>> ReadAsync(ReadInteractionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<InteractionResource>.FromJson("interactions", response.Content);
            return new ResourceSet<InteractionResource>(page, options, client);
        }
        #endif

        /// <summary>
        /// Retrieve a list of all Interactions for a Session.
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        /// <param name="pathSessionSid"> Session Sid. </param>
        /// <param name="inboundParticipantStatus"> The Inbound Participant Status of this Interaction </param>
        /// <param name="outboundParticipantStatus"> The Outbound Participant Status of this Interaction </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Interaction </returns> 
        public static ResourceSet<InteractionResource> Read(string pathServiceSid, string pathSessionSid, InteractionResource.ResourceStatusEnum inboundParticipantStatus = null, InteractionResource.ResourceStatusEnum outboundParticipantStatus = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadInteractionOptions(pathServiceSid, pathSessionSid){InboundParticipantStatus = inboundParticipantStatus, OutboundParticipantStatus = outboundParticipantStatus, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary>
        /// Retrieve a list of all Interactions for a Session.
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        /// <param name="pathSessionSid"> Session Sid. </param>
        /// <param name="inboundParticipantStatus"> The Inbound Participant Status of this Interaction </param>
        /// <param name="outboundParticipantStatus"> The Outbound Participant Status of this Interaction </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Interaction </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<InteractionResource>> ReadAsync(string pathServiceSid, string pathSessionSid, InteractionResource.ResourceStatusEnum inboundParticipantStatus = null, InteractionResource.ResourceStatusEnum outboundParticipantStatus = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadInteractionOptions(pathServiceSid, pathSessionSid){InboundParticipantStatus = inboundParticipantStatus, OutboundParticipantStatus = outboundParticipantStatus, PageSize = pageSize, Limit = limit};
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
        public static Page<InteractionResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<InteractionResource>.FromJson("interactions", response.Content);
        }

        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        ///
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns> 
        public static Page<InteractionResource> NextPage(Page<InteractionResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Preview,
                    client.Region
                )
            );

            var response = client.Request(request);
            return Page<InteractionResource>.FromJson("interactions", response.Content);
        }

        /// <summary>
        /// Fetch the previous page of records
        /// </summary>
        ///
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns> 
        public static Page<InteractionResource> PreviousPage(Page<InteractionResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(
                    Rest.Domain.Preview,
                    client.Region
                )
            );

            var response = client.Request(request);
            return Page<InteractionResource>.FromJson("interactions", response.Content);
        }

        /// <summary>
        /// Converts a JSON string into a InteractionResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> InteractionResource object represented by the provided JSON </returns> 
        public static InteractionResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<InteractionResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// A string that uniquely identifies this Interaction.
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        /// <summary>
        /// Session Sid.
        /// </summary>
        [JsonProperty("session_sid")]
        public string SessionSid { get; private set; }
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
        /// What happened in this Interaction.
        /// </summary>
        [JsonProperty("data")]
        public string Data { get; private set; }
        /// <summary>
        /// The Status of this Interaction
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public InteractionResource.StatusEnum Status { get; private set; }
        /// <summary>
        /// The inbound_participant_sid
        /// </summary>
        [JsonProperty("inbound_participant_sid")]
        public string InboundParticipantSid { get; private set; }
        /// <summary>
        /// The SID of the inbound resource.
        /// </summary>
        [JsonProperty("inbound_resource_sid")]
        public string InboundResourceSid { get; private set; }
        /// <summary>
        /// The Inbound Resource Status of this Interaction
        /// </summary>
        [JsonProperty("inbound_resource_status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public InteractionResource.ResourceStatusEnum InboundResourceStatus { get; private set; }
        /// <summary>
        /// The Twilio object type of the inbound resource.
        /// </summary>
        [JsonProperty("inbound_resource_type")]
        public string InboundResourceType { get; private set; }
        /// <summary>
        /// The URL of the inbound resource.
        /// </summary>
        [JsonProperty("inbound_resource_url")]
        public Uri InboundResourceUrl { get; private set; }
        /// <summary>
        /// The outbound_participant_sid
        /// </summary>
        [JsonProperty("outbound_participant_sid")]
        public string OutboundParticipantSid { get; private set; }
        /// <summary>
        /// The SID of the outbound resource.
        /// </summary>
        [JsonProperty("outbound_resource_sid")]
        public string OutboundResourceSid { get; private set; }
        /// <summary>
        /// The Outbound Resource Status of this Interaction
        /// </summary>
        [JsonProperty("outbound_resource_status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public InteractionResource.ResourceStatusEnum OutboundResourceStatus { get; private set; }
        /// <summary>
        /// The Twilio object type of the outbound resource.
        /// </summary>
        [JsonProperty("outbound_resource_type")]
        public string OutboundResourceType { get; private set; }
        /// <summary>
        /// The URL of the outbound resource.
        /// </summary>
        [JsonProperty("outbound_resource_url")]
        public Uri OutboundResourceUrl { get; private set; }
        /// <summary>
        /// The date this Interaction was created
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        /// <summary>
        /// The date this Interaction was updated
        /// </summary>
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        /// <summary>
        /// The URL of this Interaction.
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        private InteractionResource()
        {

        }
    }

}