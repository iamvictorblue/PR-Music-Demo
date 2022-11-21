using DataLayer.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using PRMusic.Data;
using PRMusic.Interface;
using PRMusic.Repository;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddDbContext<PRMusicContext>(options =>
        options.UseSqlServer(@"Server=DESKTOP-MK6RFPJ\SQLEXPRESS;Database=PRMusic;User ID=sa; Password=Conelperm1so")
    );
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IPlaylistRepository, PlaylistRepository>();
builder.Services.AddScoped<ISongPlayerRepository, SongPlayerRepository>();
builder.Services.AddScoped<ISongRepository, SongRepository>();
builder.Services.AddScoped<IUploadRepository, UploadRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMvc();

builder.Services.AddSwaggerGen(c =>
{
    //Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
   // c.IncludeXmlComments(xmlPath);
    c.ResolveConflictingActions(apiDecription => apiDecription.First());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();

app.MapFallbackToPage("/_Host");




app.UseSwagger(c =>
// Need to target V2 for Microsoft PowerApps and Microsoft Flow
{
    c.SerializeAsV2 = true;

});
app.UseSwaggerUI(c =>
{

    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PRMusic.API v1");
   // serves the Swagger documentation at the application root
    c.RoutePrefix = string.Empty;//page that is displayed on
});

app.UseCors(policy =>
    policy.WithOrigins("https://localhost:7051", "https://localhost:7051")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType)
);

app.UseEndpoints(endpoints =>
{

    endpoints.MapControllers();


});
app.MapControllers();

app.Run();
