using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Razor.Templating.Core;
using System.Threading.Tasks;

namespace FunctionApp2
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req)
        {
            var data = new { Name = "John Doe" };
            var result = await RazorTemplateEngine.RenderAsync("helloworld.cshtml", data);
            return new OkObjectResult(result);
        }
    }
}
