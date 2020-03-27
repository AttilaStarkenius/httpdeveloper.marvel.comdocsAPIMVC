using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using httpdeveloper.marvel.comdocsAPIMVC.Models;

namespace httpdeveloper.marvel.comdocsAPIMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SomeActionMethod(NameViewModel postdata)
        {
            const string apiKey = "1f8c669bfb6d6b86aa65400c8f3ad03d";
            const string privateKey = "b7e37b0815b570c2f84f0267060b0637698ed06a
";

            var client = new MarvelRestClient(apiKey, privateKey);
            List<ResultViewModel> results = null;

            if (postdata.Type.ToLower() == "character")
            {
                var filter = new CharacterRequestFilter { NameStartsWith = postdata.Name };
                filter.OrderBy(OrderResult.NameAscending);
                filter.Limit = 40;

                var response = client.GetCharacters(filter);

                if (response.Code == "200")
                {
                    results =
                    response.Data.Results.Select(res =>
                        new ResultViewModel { Id = res.Id, Name = res.Name, Url = res.Urls.FirstOrDefault(t => t.Type == "detail").URL }).ToList();
                }
            }
            else
            {
                var filter = new ComicRequestFilter { TitleStartsWith = postdata.Name };
                filter.OrderBy(OrderResult.NameAscending);
                filter.Limit = 40;

                var response = client.GetComics(filter);

                if (response.Code == "200")
                {
                    results =
                    response.Data.Results.Select(res =>
                        new ResultViewModel { Id = res.Id, Name = res.Title, Url = res.Urls.FirstOrDefault(t => t.Type == "detail").URL }).ToList();
                }
            }
            return Json(results);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
