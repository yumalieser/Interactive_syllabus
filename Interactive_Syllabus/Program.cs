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

// Cookie Authentication'ý ekle
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options =>
	{
		options.LoginPath = "/Login/Home"; // Varsayýlan olarak öðrenci login yolu
		options.AccessDeniedPath = "/Home/AccessDenied"; // Yetkisiz eriþim için yönlendirme
	});

// Authorization ayarlarý
builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("StudentOnly", policy => policy.RequireClaim("UserType", "Student"));
	options.AddPolicy("AcademicianOnly", policy => policy.RequireClaim("UserType", "Academician"));
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
