using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using WebPageBookCate.Data;
using WebPageBookCate.Models;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.AddDbContext<WebPageBookCateContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebPageBookCateContext") ?? throw new InvalidOperationException("Connection string 'WebPageBookCateContext' not found.")));

builder.Services.AddDefaultIdentity<DefaultUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<WebPageBookCateContext>();

//builder.Services.AddDefaultIdentity<DefaultUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<WebPageBookCateContext>();




builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<UserList>(sp => UserList.GetList(sp));

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});





var app = builder.Build();

var scope = app.Services.CreateScope();

var services= scope.ServiceProvider;



BookDatas.Initialize(services);

try
{
    BookDatas.Initialize(services);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured while attempting to seed the database");


}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseSession();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Catalog}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});

app.Run();
