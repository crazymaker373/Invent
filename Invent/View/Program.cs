using System.Diagnostics;
using Domain.Repositories;
using Domain.Services;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;
using MudBlazor.Services;

//start docker container
//var process = new Process();
//var startInfo = new ProcessStartInfo{
//    WindowStyle = ProcessWindowStyle.Hidden,
//    FileName = "cmd.exe"
//};
//process.StartInfo = startInfo;
//process.StartInfo.Arguments = "/c cd ..\\..\\Database && docker-compose down && docker-compose up -d --build";
//process.Start();
//process.WaitForExit();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StorageDbContext>( 
    options => options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"), 
        new MySqlServerVersion(new Version(8,0,27))
    )
);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IRepository<Location>, LocationRepository>();
builder.Services.AddScoped<SidebarService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();