using BlazorDevKit;
using BsBlazor;
using BsBlazor.Demo.Client.Pages.Kit.Loader;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

BdkLoaderOptions.Loading.ChangeContent<LoadingContentExample>();
BdkLoaderOptions.Error.RegisterContent<Exception, ErrorContentExample>();

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddBsBlazorServices();
await builder.Build().RunAsync();
