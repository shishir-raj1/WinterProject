using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using WinterProject.Utilities;

namespace WinterProject.StepDefinitions.APISteps
{
    [Binding]
    public class GetJsonResponseStepDefinations
    {


        [Given("User enter base url and endpoints")]
        public void GivenUserEnterBaseUrlAndEndpoints()
        {
            string endpoint = "/api/users/2";
            RestSharpMethods.SetUrl(endpoint);


        }

        [When("User call the get method of api")]
        public void WhenUserCallTheGetMethodOfApi()
        {
            RestSharpMethods.createRequest();
        }

        [Then("User get the response in api format")]
        public void ThenUserGetTheResponseInApiFormat()
        {
            var response = RestSharpMethods.GetResponse();
            if (response.StatusCode == System.Net.HttpStatusCode.OK && !string.IsNullOrEmpty(response.Content))
            {
                try
                {
                    var json = JObject.Parse(response.Content);

                    if (json.ContainsKey("data") && json["data"] != null)
                    {
                        var data = json["data"];
                        var actualEmail = data["email"]?.ToString();

                        Assert.That(actualEmail, Is.EqualTo("janet.weaver@reqres.in"), "Email does not match expected.");
                    }
                    else
                    {
                        Assert.Fail("The 'data' field is missing in the response.");
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail("Failed to parse JSON response: " + ex.Message);
                }
            }
            else
            {
                Assert.Fail("API call failed. Status: " + response.StatusCode);
            }

        }
    }
}
