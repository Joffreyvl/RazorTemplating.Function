using ClassLibrary1;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddTransient<CustomFileProvider>();
        services.AddOptions<MvcRazorRuntimeCompilationOptions>()
            .Configure<CustomFileProvider>((option, source) =>
            {
                option.FileProviders.Add(source);
            });

        services.AddRazorTemplating();
    })
    .Build();

host.Run();