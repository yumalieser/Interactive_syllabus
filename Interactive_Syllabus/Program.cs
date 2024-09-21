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

// Cookie Authentication'� ekle
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options =>
	{
		options.LoginPath = "/Login/Home"; // Varsay�lan olarak ��renci login yolu
		options.AccessDeniedPath = "/Home/AccessDenied"; // Yetkisiz eri�im i�in y�nlendirme
	});

// Authorization ayarlar�
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
