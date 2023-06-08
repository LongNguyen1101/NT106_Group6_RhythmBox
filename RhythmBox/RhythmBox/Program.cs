using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RhythmBox.Data;
using Microsoft.EntityFrameworkCore;
using RhythmBox.Repositories;
using Azure;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using RhythmBox.Repositories.Interface;
using RhythmBox.Repositories.Services;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RhythmboxdbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RhythmBox")));

builder.Services.AddScoped<IFileShare, RhythmBox.Repositories.FileShare>();
builder.Services.AddScoped<IDbUsers, DbUsers>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IForgotPassword, ForgotPassword>();
builder.Services.AddScoped<IAccount, Account>();
builder.Services.AddScoped<IAlbumsLib, AlbumsLib>();
builder.Services.AddScoped<IArtistsLib, ArtistsLib>();
builder.Services.AddScoped<ISearch, Search>();
builder.Services.AddScoped<IPlaylist, Playlists>();
builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            builder.Configuration.GetSection("AppSettings:Token").Value!))
    };
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    app.UseHsts();
//}
//else
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(options =>
//    {
//        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
//    });
//}

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
});

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseSession();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

