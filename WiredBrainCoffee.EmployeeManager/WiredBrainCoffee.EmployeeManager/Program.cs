using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.EmployeeManager.Components;
using WiredBrainCoffee.EmployeeManager.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextFactory<EmployeeManagerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeManagement") ?? throw new InvalidOperationException("Connection string 'EmployeeManagement' not found.")));

builder.Services.AddQuickGridEntityFrameworkAdapter();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	app.UseHsts();
    app.UseMigrationsEndPoint();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.Run();
