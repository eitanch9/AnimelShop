

using Microsoft.EntityFrameworkCore;
using WebApplicationAnimel.DAL;
using WebApplicationAnimel.Data;
using WebApplicationAnimel.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddTransient<IRepository<Animal>,AnimalRepository>();
builder.Services.AddDbContext<AnimalsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddControllersWithViews();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<AnimalsContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("Default", "{controller=Home}/{action=Index}");
});

app.Run(async context => { await context.Response.WriteAsync("The Web Can't opened"); });

app.Run();
