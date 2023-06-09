using BancoBadalada.Models;
using BancoBadalada.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//AAAAA
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AcademicoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionBadalada")));

builder.Services.AddScoped<IDBContextDepartamento, DBDepartamento>();
builder.Services.AddScoped<IDBContextCurso, DBCurso>();
builder.Services.AddScoped<IDBContextEmpregado, DBEmpregado>();
builder.Services.AddScoped<IDBContextHistorico , DBHistorico>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
