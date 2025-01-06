using ETMS_Blazor9.Client.Pages;
using ETMS_Blazor9.Components;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ETMS.Data;
using ETMS.Data.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<ETMSContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ETMSContext") ?? throw new InvalidOperationException("Connection string 'ETMSContext' not found.")));

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IEmployeeCourseService, EmployeeCourseService>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents()
    .AddInteractiveServerComponents();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(ETMS_Blazor9.Client._Imports).Assembly);


    


app.Run();
