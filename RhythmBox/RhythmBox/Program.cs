using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RhythmBox.Data;
using Microsoft.EntityFrameworkCore;
using RhythmBox.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RhythmboxdbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RhythmBox")));

builder.Services.AddScoped<IFileShare, RhythmBox.Repositories.FileShare>();
builder.Services.AddScoped<IDbUsers, DbUsers>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();

app.MapFallbackToPage("/_Host");

app.Run();

