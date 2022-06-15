using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Razor.Templating.Core;

namespace FunctionApp1
{
    public class Function1
    {
        [Function("Function1")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            var data = new Dictionary<string, object>() { { "Name", $"John Doe {Guid.NewGuid()}" } };
            var result = await RazorTemplateEngine.RenderAsync<object>("helloworld.cshtml", null, data);
            var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
            response.WriteString(result);
            return response;
        }
    }
}
