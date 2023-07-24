using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApplication3.Models
{
    public class Anime
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


        [JsonPropertyName("img")]
        public string Image { get; set; }

        [JsonPropertyName("urlVideo")]
        public string Video { get; set; }

        public int[] Ratings { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Anime>(this);
        
    }
}
