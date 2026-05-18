using Microsoft.FluentUI.AspNetCore.Components;
using Sandbox;
using Sandbox.Azure.Maps;
using Sandbox.Components;
using Sandbox.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddFluentUIComponents();

//Azure Maps JS Interop
builder.Services.ConfigureMarqdoujAzureMaps(builder.Configuration, builder.Environment.IsDevelopment());

//Sandbox Azure Maps JS Interop
builder.Services.AddScoped<SandboxMapsInterop>();

//Simulates getting data from an API.
builder.Services.AddScoped<IMapDataService, DataService>();

//XML documentation file readers.
builder.Services.AddScoped<IAzureMapsCSDocReader, AzureMapsCSDocReader>();
builder.Services.AddScoped<IAzureMapsUICSDocReader, AzureMapsUICSDocReader>();
builder.Services.AddScoped<IGeoJsonCSDocReader, GeoJsonCSDocReader>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
