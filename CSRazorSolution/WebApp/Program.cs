#region Additional Namespaces
using Microsoft.EntityFrameworkCore;
using WestWindSystem;
#endregion

var builder = WebApplication.CreateBuilder(args);   // WebApplication = class
                                                    // no new () statement = static class
                                                    // CreateBuilder = method => pass in args argument
                                                    // args = in-built
                                                    // build = instance

// Add services to the container.
//  Setup the connection string services for the application
//  (1) Retrieve the connection string information from your appSettings.json
var connectionString = builder.Configuration.GetConnectionString("WWDB");

//  (2) Register any "services" you wish to use
//      In our solution, our services will be created (coded) in the class library WestWindSystem
//      one of these services will be the setup of the database context connection
//      another services will be created as the application requires

builder.Services.WWBackendDependencies(options => options.UseSqlServer(connectionString));

//  This setup can be done here, locally
//  This setup can also be done elsewhere and called from this location ****

builder.Services.AddRazorPages();                   // class builder. Services (property) .AddRazorPages() (method)

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
