using System;
using NUnit.Framework;
using Reqnroll;
using RestSharp;

namespace WinterProject.StepDefinitions.APISteps
{
    [Binding]
    public class CreateUserStepDefinitions
    {
        RestClientOptions options;
        RestRequest request;
        RestClient clients;
        RestResponse response;

        [Given("User pass a base url and enpoint")]
        public void GivenUserPassABaseUrlAndEnpoint()
        {
            options = new RestClientOptions("https://reqres.in/")
            {
                MaxTimeout = -1,
            };
        }

        [When("User make a post request")]
        public void WhenUserMakeAPostRequest()
        {
            var client = new RestClient(options);
            var request = new RestRequest ("/api/users", Method.Post );
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
" + "\n" +
            @"    ""name"": ""morpheus"",
" + "\n" +
            @"    ""job"": ""leader""
" + "\n" +
            @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            response = client.Execute(request);
            Console.WriteLine(response.Content);

            if (response == null)
            {
                Console.WriteLine("Error : response object is null");
                Assert.Fail("Response object is null");
            }
        }

        [Then("User verify the request got created")]
        public void ThenUserVerifyTheRequestGotCreated()
        {
            Assert.That(response.StatusCode.ToString(), Is.EqualTo("Created"));
            Assert.That(response.IsSuccessful.ToString() == "True");
        }
    }
}
