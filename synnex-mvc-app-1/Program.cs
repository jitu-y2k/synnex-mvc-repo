using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using synnex_mvc_app_1.AutorizationRequirements;
using synnex_mvc_app_1.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();


builder.Services.AddDbContext<ApplicationDbContext>(config =>
{
    config.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddScoped<StudentRespository>();
builder.Services.AddScoped<TeacherRespository>();

builder.Services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, config =>
    {
        config.AccessDeniedPath = "/Accounts/AccessDenied";
        config.LoginPath = "/Accounts/Login";
        config.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    });

//builder.Services.AddAuthorization();

builder.Services.AddAuthorization(config =>
{
    config.AddPolicy("ShouldBe18YearsOld", policy =>
    {
        policy.AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme);
        //policy.RequireClaim("Age").RequireAssertion(context =>
        //{
        //    //return Int32.Parse(context.User.Claims.FirstOrDefault(c => c.Type == "Age")?.Value??"0") >= 18;

        //    //return Int32.Parse(context.User.Claims.FirstOrDefault(c => c.Type == "Age")?.Value ?? "0") >= 18;

        //    return context.User.Claims.FirstOrDefault(c => c.Type == "Age" && Int32.Parse(c.Value) >= 18) != null;



        //});

        policy.Requirements.Add(new MinimumAgeRequirement(18));

        

        
        
    });
});
Console.WriteLine();

// Add services to the container.
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
    builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
}
else
{
    builder.Services.AddControllersWithViews();
    builder.Services.AddRazorPages();
}



var app = builder.Build();

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
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

