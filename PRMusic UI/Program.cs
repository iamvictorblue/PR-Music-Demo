using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PRMusic_UI;
using PRMusic_UI.Services;
using PRMusic_UI.Services.Contracts;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7215/")});
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<IArtistService, ArtistService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IPlaylistService, PlaylistService>();
builder.Services.AddScoped<ISongPlayerService, SongPlayerService>();
builder.Services.AddScoped<ISongService, SongService>();
builder.Services.AddScoped<IUploadService, UploadService>();
builder.Services.AddScoped<IUserService, UserService>();



await builder.Build().RunAsync();
 