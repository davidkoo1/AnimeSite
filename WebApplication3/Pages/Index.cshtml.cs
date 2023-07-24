using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public readonly JsonFileAnimeService _animeService;
        public IEnumerable<Anime> Animes { get; private set; }

        //public JsonFileProductService ProductService { get; set; }
       // public IEnumerable<Product> Products { get; set; }

        public IndexModel(ILogger<IndexModel> logger, JsonFileAnimeService animeService/*, JsonFileProductService productService*/)
        {
            _logger = logger;
            //ProductService = productService;
            _animeService = animeService;
        }

        public void OnGet()
        {
            Animes = _animeService.GetAnimes();
            //Products = ProductService.GetProducts();
        }
    }
}