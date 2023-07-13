using BancoBadalada.Models;
using BancoBadalada.Services.Dapper;
using BancoBadalada.Services.Dapper.DATA;
using BancoBadalada.Services.Entity;
using BancoBadalada.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AcademicoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Thalita")));

builder.Services.AddScoped<IDBContextDepartamento, DBDepartamento>();
//builder.Services.AddScoped<IDBContextCurso, DBCurso>();
builder.Services.AddScoped<IDBContextCurso, DbCursoDapper>();
builder.Services.AddScoped<IDBContextEmpregado, DBEmpregado>();
builder.Services.AddScoped<IDBContextHistorico , DBHistorico>();
//builder.Services.AddScoped<IDBContextCursosOferecidos , DBCursosOferecidos>();
builder.Services.AddScoped<IDBContextCursosOferecidos , DBCursosOferecidosDapper>();
builder.Services.AddScoped<IDBContextMatricula , DBMatricula>();

builder.Services.AddSingleton<IDbConnectionFactory , DbConnectionFactory>();

Testes();

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


void Testes()
{
    //Teste FindAll Curso;
    var x = builder.Services.BuildServiceProvider();

    var y = x.GetService<IDBContextCurso>();
    var w = y.FindAll();

    int pausa = 0;
}
