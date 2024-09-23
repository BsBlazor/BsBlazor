using BlazorDevKit;
using BsBlazor;
using BsBlazor.Demo.Client.Pages.Kit.Loader;
using BsBlazor.Demo.Server.Components;
using BsBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

BdkLoaderOptions.Loading.ChangeContent<LoadingContentExample>();
BdkLoaderOptions.Error.RegisterContent<Exception, ErrorContentExample>();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddBsBlazorServices();
builder.Services.AddScoped<ISubjectService, SubjectServiceServer>();

var app = builder.Build();

app.MapGet("api/subjects", async (ISubjectService service) => await service.ListAsync());
app.MapGet("api/subjects/{id}", async (Guid id, ISubjectService service) => await service.GetAsync(id));
app.MapGet("api/subjects/error", async (ISubjectService service) =>
{
    await service.ProcessAsync();
    throw new Exception("Subject not found in the database");
});
app.MapPost("api/subjects/process/{throwError:bool}", async (bool throwError, ISubjectService service) => await service.ProcessAsync(throwError));

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
