using ClassLibrary1;
using FunctionApp2;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace FunctionApp2
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<CustomFileProvider>();
            builder.Services.AddOptions<MvcRazorRuntimeCompilationOptions>()
                .Configure<CustomFileProvider>((option, source) =>
                {
                    option.FileProviders.Add(source);
                });

            builder.Services.AddRazorTemplating();
        }
    }
}
