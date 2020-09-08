using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using IMS.Client.Shared;
using IMS.Shared;
using System.Globalization;
using Microsoft.JSInterop;
using Blazored.Modal;

namespace IMS.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<QuoteState>();
            builder.Services.AddLocalization();
            builder.Services.AddBlazoredModal();

            var host = builder.Build();

            //language selection 
            //from https://github.com/pranavkm/LocSample
            
            var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
            var result = await jsInterop.InvokeAsync<string>("blazorCulture.get");
            
            if (result != null)
            {
                var culture = new CultureInfo(result);
                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;
            }

            await host.RunAsync();
        }
    }
}
