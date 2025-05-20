using System;
using NUnit.Framework;
using Reqnroll;
using RestSharp;

namespace WinterProject.StepDefinitions.APISteps
{
    [Binding]
    public class DemoTestStepDefinitions
    {
        RestClientOptions options;
        RestRequest request;
        RestClient clients;
        RestResponse response;


        [Given("User pass base url and endpoints")]
        public void GivenUserPassBaseUrlAndEndpoints()
        {
            options = new RestClientOptions("https://demoqa.com")
            {
                MaxTimeout = -1,
            };
        }

        [When("User Request a Get method")]
        public async Task WhenUserRequestAGetMethod()
        {
            clients = new RestClient(options);
            request = new RestRequest("/BookStore/V1/Books", Method.Get);
            response = await clients.ExecuteAsync(request);
            Console.WriteLine(response.Content);
        }

        [Then("User Verify the Response")]
        public void ThenUserVerifyTheResponse()
        {
            Assert.That(response.StatusCode.ToString(), Is.EqualTo("OK"));
            Assert.That(response.IsSuccessful.ToString() == "True");
        }
    }
}
