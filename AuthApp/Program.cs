using AuthApp.Authorization;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAuthentication("MyAuth")
    .AddCookie("MyAuth", options =>
    {
        options.Cookie.Name = "MyAuth";
        options.ExpireTimeSpan = TimeSpan.FromSeconds(10);
        // options.LoginPath
        // options.AccessDeniedPath
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim("Admin"));
    options.AddPolicy("HROnly", policy => policy.RequireClaim("Department", "HR"));
    options.AddPolicy("HR Manager", policy =>
    {
        policy.RequireClaim("Department", "HR")
            .RequireClaim("Manager")
            .Requirements.Add(new HRManagerRequirement(3));
    });
});

builder.Services.AddSingleton<IAuthorizationHandler, HRManagerRequirementHandler>();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
