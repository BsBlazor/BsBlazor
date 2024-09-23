using BlazorDevKit;
using BsBlazor;
using BsBlazor.Demo.Client.Pages.Kit.Loader;
using BsBlazor.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

BdkLoaderOptions.Loading.ChangeContent<LoadingContentExample>();
BdkLoaderOptions.Error.RegisterContent<Exception, ErrorContentExample>();

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("server"));
builder.Services.AddHttpClient("server", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddBsBlazorServices();
builder.Services.AddScoped<ISubjectService, SubjectServiceClient>();
await builder.Build().RunAsync();
