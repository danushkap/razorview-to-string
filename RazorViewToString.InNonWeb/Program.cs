using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.ObjectPool;
using Microsoft.Extensions.PlatformAbstractions;
using RazorViewToString.InNonWeb.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace RazorViewToString.InNonWeb
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static async Task Main()
        {
            ConfigureServices();

            var result = await _serviceProvider
                .GetRequiredService<RazorViewToStringRenderer>()
                .RenderViewToStringAsync(
                    @"Views\Profile.cshtml",
                    new ProfileModel
                    {
                        FirstName = "Danushka",
                        LastName = "Padukka"
                    });

            Console.WriteLine(result);

            Console.ReadLine();
        }

        private static void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddLogging();

            services.AddSingleton(PlatformServices.Default.Application);
            services.AddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();
            services.AddSingleton<DiagnosticSource>(new DiagnosticListener("Microsoft.AspNetCore"));
            services.AddSingleton<RazorViewToStringRenderer>();
            services.AddSingleton<IHostingEnvironment>(new HostingEnvironment
            {
                ApplicationName = Assembly.GetEntryAssembly().GetName().Name
            });
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.FileProviders.Clear();
                options.FileProviders.Add(new PhysicalFileProvider(Directory.GetCurrentDirectory()));
            });
            services.AddMvc();

            _serviceProvider = services.BuildServiceProvider();
        }
    }
}
