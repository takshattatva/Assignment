//Scaffold - DbContext “Host = localhost; Database = Assignment; Username = postgres; Password = !@12Taksh” Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir Models


using Assignment.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Assignment.BAL.Interface;
using Assignment.BAL.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AssignmentContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ITaskTable, TaskTableRepo>();

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
    pattern: "{controller=Task}/{action=TaskTable}/{id?}");

app.Run();
