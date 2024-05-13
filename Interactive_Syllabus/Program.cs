using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//builder.Services.AddAuthentication
//    (CookieAuthenticationDefaults.AuthenticationScheme)
//        .AddCookie( x=>
//{
//    x.LoginPath = "/Login/Home/";
//});

builder.Services.AddAuthentication
	(CookieAuthenticationDefaults.AuthenticationScheme)
		.AddCookie(options =>
		{
			options.Cookie.Name = ".NetCoreMvc.auth";
			options.LoginPath = "/Login/Home/";
			options.AccessDeniedPath = "/Login/Home/";
		});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection(); 
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication ();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Home}/{id?}");

app.Run();
