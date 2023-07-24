using System.Text.Json;
using WebApplication3.Models;
using WebApplication3.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddTransient<JsonFileAnimeService>();
//builder.Services.AddTransient<JsonFileProductService>();

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

app.UseAuthorization();

app.MapRazorPages();
/*
app.MapGet("/animes", (context) =>
{
    var animes = app.Services.GetService<JsonFileAnimeService>().GetAnimes();
    var json = JsonSerializer.Serialize<IEnumerable<Anime>>(animes);
    return context.Response.WriteAsync(json);
});
*/
app.MapControllers();
app.MapBlazorHub();
app.Run();
