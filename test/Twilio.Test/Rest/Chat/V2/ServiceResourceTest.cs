/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Chat.V2;

namespace Twilio.Tests.Rest.Chat.V2 
{

    [TestFixture]
    public class ServiceTest : TwilioTest 
    {
        [Test]
        public void TestFetchRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Chat,
                "/v2/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                ServiceResource.Fetch("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestFetchResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"consumption_report_interval\": 100,\"date_created\": \"2015-07-30T20:00:00Z\",\"date_updated\": \"2015-07-30T20:00:00Z\",\"default_channel_creator_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"default_channel_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"default_service_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"friendly_name\": \"friendly_name\",\"limits\": {\"channel_members\": 100,\"user_channels\": 250},\"links\": {\"channels\": \"https://chat.twilio.com/v2/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels\",\"users\": \"https://chat.twilio.com/v2/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Users\",\"roles\": \"https://chat.twilio.com/v2/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Roles\",\"bindings\": \"https://chat.twilio.com/v2/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Bindings\"},\"notifications\": {},\"post_webhook_url\": \"post_webhook_url\",\"pre_webhook_url\": \"pre_webhook_url\",\"pre_webhook_retry_count\": 2,\"post_webhook_retry_count\": 3,\"reachability_enabled\": false,\"read_status_enabled\": false,\"sid\": \"ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"typing_indicator_timeout\": 100,\"url\": \"https://chat.twilio.com/v2/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"webhook_filters\": [\"webhook_filters\"],\"webhook_method\": \"webhook_method\",\"media\": {\"size_limit_mb\": 150,\"compatibility_message\": \"media compatibility message\"}}"
                                     ));

            var response = ServiceResource.Fetch("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestDeleteRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Delete,
                Twilio.Rest.Domain.Chat,
                "/v2/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                ServiceResource.Delete("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestDeleteResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.NoContent,
                                         "null"
                                     ));

            var response = ServiceResource.Delete("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestCreateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Post,
                Twilio.Rest.Domain.Chat,
                "/v2/Services",
                ""
            );
            request.AddPostParam("FriendlyName", Serialize("FriendlyName"));
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                ServiceResource.Create("FriendlyName", client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestCreateResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.Created,
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"consumption_report_interval\": 100,\"date_created\": \"2015-07-30T20:00:00Z\",\"date_updated\": \"2015-07-30T20:00:00Z\",\"default_channel_creator_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"default_channel_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"default_service_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"friendly_name\": \"friendly_name\",\"limits\": {\"channel_members\": 100,\"user_channels\": 250},\"links\": {\"channels\": \"https://chat.twilio.com/v2/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels\",\"users\": \"https://chat.twilio.com/v2/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Users\",\"roles\": \"https://chat.twilio.com/v2/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Roles\",\"bindings\": \"https://chat.twilio.com/v2/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Bindings\"},\"notifications\": {},\"post_webhook_url\": \"post_webhook_url\",\"pre_webhook_url\": \"pre_webhook_url\",\"pre_webhook_retry_count\": 2,\"post_webhook_retry_count\": 3,\"reachability_enabled\": false,\"read_status_enabled\": false,\"sid\": \"ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"typing_indicator_timeout\": 100,\"url\": \"https://chat.twilio.com/v2/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"webhook_filters\": [\"webhook_filters\"],\"webhook_method\": \"webhook_method\",\"media\": {\"size_limit_mb\": 150,\"compatibility_message\": \"media compatibility message\"}}"
                                     ));

            var response = ServiceResource.Create("FriendlyName", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Chat,
                "/v2/Services",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                ServiceResource.Read(client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestReadEmptyResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"meta\": {\"first_page_url\": \"https://chat.twilio.com/v2/Services?PageSize=50&Page=0\",\"key\": \"services\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://chat.twilio.com/v2/Services?PageSize=50&Page=0\"},\"services\": []}"
                                     ));

            var response = ServiceResource.Read(client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadFullResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"meta\": {\"first_page_url\": \"https://chat.twilio.com/v2/Services?PageSize=50&Page=0\",\"key\": \"services\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://chat.twilio.com/v2/Services?PageSize=50&Page=0\"},\"services\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"consumption_report_interval\": 100,\"date_created\": \"2015-07-30T20:00:00Z\",\"date_updated\": \"2015-07-30T20:00:00Z\",\"default_channel_creator_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"default_channel_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"default_service_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"friendly_name\": \"friendly_name\",\"limits\": {\"channel_members\": 100,\"user_channels\": 250},\"links\": {\"channels\": \"https://chat.twilio.com/v2/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels\",\"users\": \"https://chat.twilio.com/v2/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Users\",\"roles\": \"https://chat.twilio.com/v2/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Roles\",\"bindings\": \"https://chat.twilio.com/v2/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Bindings\"},\"notifications\": {},\"post_webhook_url\": \"post_webhook_url\",\"pre_webhook_url\": \"pre_webhook_url\",\"pre_webhook_retry_count\": 2,\"post_webhook_retry_count\": 3,\"reachability_enabled\": false,\"read_status_enabled\": false,\"sid\": \"ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"typing_indicator_timeout\": 100,\"url\": \"https://chat.twilio.com/v2/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"webhook_filters\": [\"webhook_filters\"],\"webhook_method\": \"webhook_method\",\"media\": {\"size_limit_mb\": 150,\"compatibility_message\": \"media compatibility message\"}}]}"
                                     ));

            var response = ServiceResource.Read(client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestUpdateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Post,
                Twilio.Rest.Domain.Chat,
                "/v2/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                ServiceResource.Update("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestUpdateResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"consumption_report_interval\": 100,\"date_created\": \"2015-07-30T20:00:00Z\",\"date_updated\": \"2015-07-30T20:00:00Z\",\"default_channel_creator_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"default_channel_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"default_service_role_sid\": \"RLaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"friendly_name\": \"friendly_name\",\"limits\": {\"channel_members\": 500,\"user_channels\": 600},\"links\": {\"channels\": \"https://chat.twilio.com/v2/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels\",\"users\": \"https://chat.twilio.com/v2/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Users\",\"roles\": \"https://chat.twilio.com/v2/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Roles\",\"bindings\": \"https://chat.twilio.com/v2/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Bindings\"},\"notifications\": {\"added_to_channel\": {\"enabled\": false,\"template\": \"notifications.added_to_channel.template\"},\"invited_to_channel\": {\"enabled\": false,\"template\": \"notifications.invited_to_channel.template\"},\"new_message\": {\"enabled\": false,\"template\": \"notifications.new_message.template\",\"badge_count_enabled\": true},\"removed_from_channel\": {\"enabled\": false,\"template\": \"notifications.removed_from_channel.template\"}},\"post_webhook_url\": \"post_webhook_url\",\"pre_webhook_url\": \"pre_webhook_url\",\"pre_webhook_retry_count\": 2,\"post_webhook_retry_count\": 3,\"reachability_enabled\": false,\"read_status_enabled\": false,\"sid\": \"ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"typing_indicator_timeout\": 100,\"url\": \"https://chat.twilio.com/v2/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"webhook_filters\": [\"webhook_filters\"],\"webhook_method\": \"webhook_method\",\"media\": {\"size_limit_mb\": 150,\"compatibility_message\": \"new media compatibility message\"}}"
                                     ));

            var response = ServiceResource.Update("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }
    }

}