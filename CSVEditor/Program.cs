using CSVEditor.Data;
using CSVEditor.Services;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CSVDbContext>(context => 
    context.UseSqlServer(builder
        .Configuration.GetConnectionString("Default")
    ));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute("default",
    "{controller=User}/{action=Index}/{id?}");

using (IServiceScope scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<CSVDbContext>(); 
        context.Database.Migrate(); 
    }
    catch (Exception ex)
    {
        ErrorLogger.LogError(ex);
    }
}

app.Run();