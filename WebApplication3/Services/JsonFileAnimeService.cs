using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using WebApplication3.Models;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication3.Services
{
    public class JsonFileAnimeService
    {
        public JsonFileAnimeService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "anime.json"); }
        }

        public IEnumerable<Anime> GetAnimes()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Anime[]>(jsonFileReader.ReadToEnd(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
        }

        public void addRating(int animeId, int rating)
        {
            IEnumerable<Anime> animes = GetAnimes();

            var query = animes.First(x => x.Id == animeId);

            if(query.Ratings == null)
            {
                query.Ratings = new int[] { rating };
            }
            else
            {
                var ratings = query.Ratings.ToList();
                ratings.Add(rating);
                query.Ratings = ratings.ToArray();
            }

            using(var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Anime>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                        animes
                );
            }
        }
    }
}