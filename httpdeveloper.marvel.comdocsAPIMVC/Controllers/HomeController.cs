using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using httpdeveloper.marvel.comdocsAPIMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Marvel;
using Marvel.Api;
using Marvel.Api.Filters;
using Marvel.Api.Model.DomainObjects;
using Marvel.Api.Results;
using Marvel.Api.Model;
using DocumentFormat.OpenXml.ExtendedProperties;

namespace httpdeveloper.marvel.comdocsAPIMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(/*NameViewModel postdata*/)
        {

            const string apiKey = "1f8c669bfb6d6b86aa65400c8f3ad03d";
            const string privateKey = "b7e37b0815b570c2f84f0267060b0637698ed06a";

            var client = new MarvelRestClient(apiKey, privateKey);
            List<ResultViewModel> results = null;

            //NameViewModel postdata = "hulk";

            //if (postdata.Type.ToLower() == "character")
            //{
                var filter = new CharacterRequestFilter { NameStartsWith = "hulk" };
                filter.OrderBy(OrderResult.NameAscending);
            //filter.Limit = 40;
            filter.Limit = 1;


            var response = client.FindCharacters(filter);

                //if (response.Code == "200")
                //{
                    results =
                    response.Data.Results.Select(res =>
                        new ResultViewModel { Id = res.Id, Description = res.Description, Name = res.Name, Url = res.Urls.FirstOrDefault(t => t.Type == "detail").URL }).ToList();
            //    }
            //}
            //else
            //{

            ViewBag.Message = results;





            var comicFilter = new ComicRequestFilter { TitleStartsWith = "hulk" };
            comicFilter.OrderBy(OrderResult.NameAscending);
            comicFilter.Limit = 40;
            //comicFilter.Limit = 1;

            var comicFilterresponse = client.FindComics(comicFilter);

                //if (response.Code == "200")
                //{
                    results =
                    response.Data.Results.Select(res =>
                        new ResultViewModel { Id = res.Id, Description = res.Description, Name = res.Name, Url = res.Urls.FirstOrDefault(t => t.Type == "detail").URL }).ToList();
            //}
            var firstResultDescription = results.FirstOrDefault();

            //var characterList = 

            //var characterList = firstResultDescription.Description.

            var storyFilter = new httpdeveloper.marvel.comdocsAPIMVC.Filters.StoryRequestFilter {   };
            filter.OrderBy(OrderResult.NameAscending);
            filter.Limit = 40;
            //filter.Limit = 1;

            var storyFilterresponse = client.FindStoryCharacters("1009351");

            //if (response.Code == "200")
            //{
            //results =
            //response.Data.Results.Select(res =>
            //    new ResultViewModel { Id = res.Id, Description = res.Description, Name = res.Name, Url = res.Urls.FirstOrDefault(t => t.Type == "detail").URL }).ToList();
            ////    }
            ////}

            List<CharactersInResultViewModel> charactersResults = null;

            charactersResults =
            response.Data.Results.Select(res =>
                new CharactersInResultViewModel { Name = res.Name }).ToList();
            //    }
            //}

            //var storyFilterresponseCharacterList = charactersResults;

            //return Json(storyFilterresponseCharacterList);

            return View("Index", charactersResults);

            ////return View(storyFilterresponseCharacterList);

            //return Json(results);
        }
            
        










        //[HttpPost]
        //[HttpGet]
        //public IActionResult Index(/*NameViewModel postdata*/)
        //{

        //    const string apiKey = "1f8c669bfb6d6b86aa65400c8f3ad03d";
        //    const string privateKey = "b7e37b0815b570c2f84f0267060b0637698ed06a";

        //    const string characterName = "hulk";

        //    var client = new MarvelRestClient(apiKey, privateKey);
        //    List<ResultViewModel> results = null;

        //    //if (postdata.Type.ToLower() == "character")
        //    //{
        //    var filter = new StoryRequestFilter { /*Characters.Equals == The Hulk*//*NameStartsWith = postdata.Name*/ };
        //    filter.OrderBy(OrderResult.NameAscending);
        //    //filter.Comics.Contains("hulk");
        //    //filter.Comics.Where(res.Id == 30)
        //    //filter.Series.
        //    filter.Limit = 1;

        //    //var response = client.FindCharacters(filter);

        //    var response = client.FindStories(filter);

        //    //if (response.Code == "200")
        //    //    {
        //    //results =
        //    //response.Data.Results./*Where(results.*//*Where(response.Data.Results.).*/Select(res =>
        //    //                //new ResultViewModel { Id = 30/*res.Id*/, Description = res.Description,  Name = "The second volume containing the Hulk\u0027s early adventures with appearances by the Sub-Mariner, the Mandarin, Ka-Zar and Nick Fury" /*res.Title*/, Url = "http://gateway.marvel.com/v1/public/stories/30" /*res.ResourceURI*/ })./*Where(response.Data.Results.Id*//*.Where(res.Id == 30)*//*.*/ToList()/*.Where(Id == 30)*//*.FirstOrDefault*//*(*//*t => t.Type == "detail").URL }).ToList(*//*)*/;
        //    //                new ResultViewModel { Id = 30, Description = res.Description, Name = res.Title, Url = "http://gateway.marvel.com/v1/public/stories/30/" })./*Where(response.Data.Results.Id*//*.Where(res.Id == 30)*//*.*/ToList()/*.Where(Id == 30)*//*.FirstOrDefault*//*(*//*t => t.Type == "detail").URL }).ToList(*//*)*/;

        //    results =
        //            response.Data.Results.Select(res =>
        //                new ResultViewModel { Id = res.Id, Description = res.Description, Name = res.Title, Url = res.ResourceURI.FirstOrDefault().ToString() }).ToList();




        //    //}.

        //    //results.Where()

        //    //else
        //    //{
        //    //    var filter = new ComicRequestFilter { TitleStartsWith = postdata.Name };
        //    //    filter.OrderBy(OrderResult.NameAscending);
        //    //    filter.Limit = 40;

        //    //    var response = client.FindComics(filter);

        //    //    if (response.Code == "200")
        //    //    {
        //    //        results =
        //    //        response.Data.Results.Select(res =>
        //    //            new ResultViewModel { Id = res.Id, Name = res.Title, Url = res.Urls.FirstOrDefault(t => t.Type == "detail").URL }).ToList();
        //    //    }
        //    //}
        //    return Json(results/*.ToList()*/);
        //    //return View(results);
        //}

            //return View();
        

    

        //[HttpPost]
        //public JsonResult SomeActionMethod(NameViewModel postdata)
        //{
        //    const string apiKey = "1f8c669bfb6d6b86aa65400c8f3ad03d";
        //    const string privateKey = "b7e37b0815b570c2f84f0267060b0637698ed06a";


        //    var client = new MarvelRestClient(apiKey, privateKey);
        //    List<ResultViewModel> results = null;

        //    if (postdata.Type.ToLower() == "character")
        //    {
        //        var filter = new CharacterRequestFilter { NameStartsWith = postdata.Name };
        //        filter.OrderBy(OrderResult.NameAscending);
        //        filter.Limit = 40;

        //        var response = client.FindCharacters(filter);

        //        if (response.Code == "200")
        //        {
        //            results =
        //            response.Data.Results.Select(res =>
        //                new ResultViewModel { Id = res.Id, Name = res.Name, Url = res.Urls.FirstOrDefault(t => t.Type == "detail").URL }).ToList();
        //        }
        //    }
        //    else
        //    {
        //        var filter = new ComicRequestFilter { TitleStartsWith = postdata.Name };
        //        filter.OrderBy(OrderResult.NameAscending);
        //        filter.Limit = 40;

        //        var response = client.FindComics(filter);

        //        if (response.Code == "200")
        //        {
        //            results =
        //            response.Data.Results.Select(res =>
        //                new ResultViewModel { Id = res.Id, Name = res.Title, Url = res.Urls.FirstOrDefault(t => t.Type == "detail").URL }).ToList();
        //        }
        //    }
        //    return Json(results);
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
