using BlazorDevKit;
using BsBlazor;
using BsBlazor.Demo.Client.Pages.Kit.Loader;
using BsBlazor.Demo.Server.Components;

var builder = WebApplication.CreateBuilder(args);

BdkLoaderOptions.Loading.ChangeContent<LoadingContentExample>();
BdkLoaderOptions.Error.RegisterContent<Exception, ErrorContentExample>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddBsBlazorServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BsBlazor.Demo.Client._Imports).Assembly);

app.Run();
