using Microsoft.EntityFrameworkCore;
using VendorAccessGovernance.Infrastructure.Persistence;
using VendorAccessGovernance.Infrastructure.Repositories;
using VendorAccessGovernance.Application.Abstractions;
using VendorAccessGovernance.Application.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<VendorAccessDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAccessRequestRepository, AccessRequestRepository>();
builder.Services.AddScoped<IVendorRepository, VendorRepository>();
builder.Services.AddScoped<IExternalWorkerRepository, ExternalWorkerRepository>();

builder.Services.AddScoped<IAccessRequestService, AccessRequestService>();
builder.Services.AddScoped<IVendorService, VendorService>();
builder.Services.AddScoped<IExternalWorkerService, ExternalWorkerService>();

builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AccessRequests}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
