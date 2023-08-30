using Blazored.Toast;
using SAPConnection.Data;
using Microsoft.EntityFrameworkCore;
using Blazored.Modal;
using SAPConnection.Data.Services;
using Microsoft.AspNetCore.Authentication.Negotiate;

using CurrieTechnologies.Razor.SweetAlert2;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SAPConnectionContextConnection") ?? throw new InvalidOperationException("Connection string 'SAPConnectionContextConnection' not found.");

builder.Services.AddDbContextFactory<MyDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Transient);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<ApplicationUserService>();
builder.Services.AddScoped<ApplicationUser>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<WorkFlowService>();
builder.Services.AddScoped<ApproversService>();
builder.Services.AddScoped<ShiftInchargeService>();
builder.Services.AddSingleton<CustomTheme>();
builder.Services.AddSession();
builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();
builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});



builder.Services.AddScoped<StaticApproverService>();
builder.Services.AddSession();
builder.Services.AddBlazoredModal();
builder.Services.AddBlazoredToast();
builder.Services.AddControllers();
builder.Services.AddAuthorization();
builder.Services.AddSweetAlert2();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
