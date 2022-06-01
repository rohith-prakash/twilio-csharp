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
using Twilio.Rest.Supersim.V1;

namespace Twilio.Tests.Rest.Supersim.V1
{

    [TestFixture]
    public class EsimProfileTest : TwilioTest
    {
        [Test]
        public void TestCreateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Post,
                Twilio.Rest.Domain.Supersim,
                "/v1/ESimProfiles",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                EsimProfileResource.Create(client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestCreateDefaultSmdpResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.Created,
                                         "{\"sid\": \"HPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"iccid\": null,\"sim_sid\": null,\"status\": \"new\",\"eid\": \"89049032005008882600033489aaaaaa\",\"smdp_plus_address\": null,\"matching_id\": null,\"activation_code\": null,\"error_code\": null,\"error_message\": null,\"date_created\": \"2020-09-01T20:00:00Z\",\"date_updated\": \"2020-09-01T20:00:00Z\",\"url\": \"https://supersim.twilio.com/v1/ESimProfiles/HPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"
                                     ));

            var response = EsimProfileResource.Create(client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestCreateActivationCodeResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.Created,
                                         "{\"sid\": \"HPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"iccid\": null,\"sim_sid\": null,\"status\": \"new\",\"eid\": null,\"smdp_plus_address\": null,\"matching_id\": null,\"activation_code\": null,\"error_code\": null,\"error_message\": null,\"date_created\": \"2020-09-01T20:00:00Z\",\"date_updated\": \"2020-09-01T20:00:00Z\",\"url\": \"https://supersim.twilio.com/v1/ESimProfiles/HPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"
                                     ));

            var response = EsimProfileResource.Create(client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestCreateWithCallbackResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.Created,
                                         "{\"sid\": \"HPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"iccid\": null,\"sim_sid\": null,\"status\": \"reserving\",\"eid\": \"89049032005008882600033489aaaaaa\",\"smdp_plus_address\": null,\"matching_id\": null,\"activation_code\": null,\"error_code\": null,\"error_message\": null,\"date_created\": \"2020-09-01T20:00:00Z\",\"date_updated\": \"2020-09-01T20:00:00Z\",\"url\": \"https://supersim.twilio.com/v1/ESimProfiles/HPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"
                                     ));

            var response = EsimProfileResource.Create(client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestFetchRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Supersim,
                "/v1/ESimProfiles/HPXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                EsimProfileResource.Fetch("HPXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestFetchDefaultSmdpResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"sid\": \"HPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"iccid\": \"8988307aaaaaaaaaaaaa\",\"sim_sid\": \"HSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"status\": \"available\",\"eid\": \"89049032005008882600033489aaaaaa\",\"smdp_plus_address\": \"sm-dp-plus.twilio.com\",\"matching_id\": null,\"activation_code\": null,\"error_code\": null,\"error_message\": null,\"date_created\": \"2020-09-01T20:00:00Z\",\"date_updated\": \"2020-09-01T20:00:00Z\",\"url\": \"https://supersim.twilio.com/v1/ESimProfiles/HPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"
                                     ));

            var response = EsimProfileResource.Fetch("HPXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestFetchActivationCodeResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"sid\": \"HPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"iccid\": \"8988307aaaaaaaaaaaaa\",\"sim_sid\": \"HSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"status\": \"available\",\"eid\": null,\"smdp_plus_address\": \"sm-dp-plus.twilio.com\",\"matching_id\": \"AAAAA-BBBBB-CCCCC-DDDDD-EEEEE\",\"activation_code\": \"1$SM-DP-PLUS.TWILIO.COM$AAAAA-BBBBB-CCCCC-DDDDD-EEEEE\",\"error_code\": null,\"error_message\": null,\"date_created\": \"2020-09-01T20:00:00Z\",\"date_updated\": \"2020-09-01T20:00:00Z\",\"url\": \"https://supersim.twilio.com/v1/ESimProfiles/HPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"
                                     ));

            var response = EsimProfileResource.Fetch("HPXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Supersim,
                "/v1/ESimProfiles",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                EsimProfileResource.Read(client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestReadAllResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"esim_profiles\": [{\"sid\": \"HPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"iccid\": \"8988307aaaaaaaaaaaaa\",\"sim_sid\": \"HSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"status\": \"available\",\"eid\": \"89049032005008882600033489aaaaaa\",\"smdp_plus_address\": \"sm-dp-plus.twilio.com\",\"matching_id\": null,\"activation_code\": null,\"error_code\": null,\"error_message\": null,\"date_created\": \"2020-09-01T20:00:00Z\",\"date_updated\": \"2020-09-01T20:00:00Z\",\"url\": \"https://supersim.twilio.com/v1/ESimProfiles/HPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}],\"meta\": {\"first_page_url\": \"https://supersim.twilio.com/v1/ESimProfiles?PageSize=50&Page=0\",\"key\": \"esim_profiles\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://supersim.twilio.com/v1/ESimProfiles?PageSize=50&Page=0\"}}"
                                     ));

            var response = EsimProfileResource.Read(client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadByEidResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"esim_profiles\": [{\"sid\": \"HPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"iccid\": \"8988307aaaaaaaaaaaaa\",\"sim_sid\": \"HSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"status\": \"available\",\"eid\": \"89049032005008882600033489aaaaaa\",\"smdp_plus_address\": \"sm-dp-plus.twilio.com\",\"matching_id\": null,\"activation_code\": null,\"error_code\": null,\"error_message\": null,\"date_created\": \"2020-09-01T20:00:00Z\",\"date_updated\": \"2020-09-01T20:00:00Z\",\"url\": \"https://supersim.twilio.com/v1/ESimProfiles/HPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}],\"meta\": {\"first_page_url\": \"https://supersim.twilio.com/v1/ESimProfiles?Eid=89049032005008882600033489aaaaaa&PageSize=50&Page=0\",\"key\": \"esim_profiles\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://supersim.twilio.com/v1/ESimProfiles?Eid=89049032005008882600033489aaaaaa&PageSize=50&Page=0\"}}"
                                     ));

            var response = EsimProfileResource.Read(client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadBySimSidResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"esim_profiles\": [{\"sid\": \"HPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"iccid\": \"8988307aaaaaaaaaaaaa\",\"sim_sid\": \"HSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"status\": \"available\",\"eid\": \"89049032005008882600033489aaaaaa\",\"smdp_plus_address\": \"sm-dp-plus.twilio.com\",\"matching_id\": null,\"activation_code\": null,\"error_code\": null,\"error_message\": null,\"date_created\": \"2020-09-01T20:00:00Z\",\"date_updated\": \"2020-09-01T20:00:00Z\",\"url\": \"https://supersim.twilio.com/v1/ESimProfiles/HPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}],\"meta\": {\"first_page_url\": \"https://supersim.twilio.com/v1/ESimProfiles?SimSid=HSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa&PageSize=50&Page=0\",\"key\": \"esim_profiles\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://supersim.twilio.com/v1/ESimProfiles?SimSid=HSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa&PageSize=50&Page=0\"}}"
                                     ));

            var response = EsimProfileResource.Read(client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadByStatusResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"esim_profiles\": [{\"sid\": \"HPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"iccid\": \"8988307aaaaaaaaaaaaa\",\"sim_sid\": \"HSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"status\": \"downloaded\",\"eid\": \"89049032005008882600033489aaaaaa\",\"smdp_plus_address\": \"sm-dp-plus.twilio.com\",\"matching_id\": null,\"activation_code\": null,\"error_code\": null,\"error_message\": null,\"date_created\": \"2020-09-01T20:00:00Z\",\"date_updated\": \"2020-09-01T20:00:00Z\",\"url\": \"https://supersim.twilio.com/v1/ESimProfiles/HPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}],\"meta\": {\"first_page_url\": \"https://supersim.twilio.com/v1/ESimProfiles?Status=downloaded&PageSize=50&Page=0\",\"key\": \"esim_profiles\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://supersim.twilio.com/v1/ESimProfiles?Status=downloaded&PageSize=50&Page=0\"}}"
                                     ));

            var response = EsimProfileResource.Read(client: twilioRestClient);
            Assert.NotNull(response);
        }
    }

}