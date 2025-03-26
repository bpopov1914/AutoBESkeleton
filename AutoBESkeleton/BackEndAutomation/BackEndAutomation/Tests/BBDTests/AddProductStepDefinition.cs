using AventStack.ExtentReports;
using BackEndAutomation.Rest.Calls;
using BackEndAutomation.Rest.DataManagement;
using BackEndAutomation.Utilities;
using Reqnroll;
using RestSharp;
using System.Drawing.Text;

namespace BackEndAutomation.Tests.BBDTests
{
    [Binding]
    public class AddProductStepDefinition
    {
        private RestCalls restCalls = new RestCalls();
        private ResponseDataExtractors extractResponseData = new ResponseDataExtractors();
        private readonly ScenarioContext _scenarioContext;
        private ExtentTest _test;
        private RestResponse response;

        public AddProductStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _test = scenarioContext.Get<ExtentTest>("ExtentTest");
        }

        [When(@"Product with product_id:""(.*)"", name:""(.*)"", quantity:(.*), price:(.*) and description:""(.*)"" is added")]

        public void AddProduct(string product_id, string name, int quantity, double price, string description)
        {
            string token = _scenarioContext.Get<string>("UserToken");
            string parameters = $"product_id={product_id}" +
                $"&name={name}" +
                $"&quantity={quantity}" +
                $"&price={price}" +
                $"&description={description}"; ;
            response = restCalls.AddProduct(token, parameters);

        }

        [Then(@"the response message is ""Product added successfully""")]
        public void ValidateProductIsAdded()
        {
            string expectedMessage = "Product added successfully";
            string actualMessage = extractResponseData.ExtractStockMessage(response.Content);
            UtilitiesMethods.AssertEqual(
                expectedMessage,
                actualMessage,
                "Oops, the product was not added.",
                _scenarioContext);
        }
    }
}
