
using Microsoft.EntityFrameworkCore;
using Model.DAL;
using Model.Models;
using Model.Repository;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddTransient<AnimalRepository>();
builder.Services.AddTransient<CommentRepoditory>();
builder.Services.AddTransient<CategortyRepository>();
builder.Services.AddDbContext<AnimalsContext>(options => options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
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
    endpoints.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{Id?}");
});

app.Run(async context => { await context.Response.WriteAsync("The Web Can't opened"); });

app.Run();
