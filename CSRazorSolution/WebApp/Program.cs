var builder = WebApplication.CreateBuilder(args);   // WebApplication = class
                                                    // no new () statement = static class
                                                    // CreateBuilder = method => pass in args argument
                                                    // args = in-built
                                                    // build = instance
// Add services to the container.
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
