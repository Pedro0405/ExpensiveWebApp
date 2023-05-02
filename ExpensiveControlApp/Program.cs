using ExpensiveControlApp.infra.Database;
using ExpensiveControlApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ExpensiveControlContext>();
builder.Services.AddScoped<IExpensiveServices, ExpensiveServices>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Expensive}/{action=Index}/{id?}");

app.Run();
