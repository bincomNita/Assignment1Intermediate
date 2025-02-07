
using CollegeApp.Data;
using CollegeApp.Repositories.Interface;
using CollegeApp.Repositories.Services;

var builder = WebApplication.CreateBuilder(args);
var constring = builder.Configuration.GetConnectionString("Default");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSqlServer<AppDbContext>(constring,opts=>opts.EnableRetryOnFailure());
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=AddStudent}/{id?}");

app.Run();
