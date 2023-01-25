using System.Diagnostics;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Domain.Repositories;
using Domain.Services;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using MudBlazor.Services;

//start docker container
var process = new Process();
var startInfo = new ProcessStartInfo{
    WindowStyle = ProcessWindowStyle.Hidden,
    FileName = "cmd.exe"
};
process.StartInfo = startInfo;
process.StartInfo.Arguments = "/c cd ..\\..\\Database && docker-compose down && docker-compose up -d --build";
//process.Start();
//process.WaitForExit();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StorageDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddBlazorise( options =>
    {
        options.Immediate = true;
    } ).AddBootstrapProviders()
    .AddFontAwesomeIcons();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddSingleton<IHashGeneratorService, HashGeneratorService>();
builder.Services.AddScoped<SidebarService>();
builder.Services.AddSingleton<ViewRefreshService>();
builder.Services.AddSingleton<SerializeService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()){
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
