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
using RestSharp;
using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using DocumentFormat.OpenXml.Wordprocessing;

namespace httpdeveloper.marvel.comdocsAPIMVC.Controllers
{
    public class HomeController : Controller
    {







        private const string StoriesUrlSegment = "/public/stories";


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /*public virtual RestResponse*/

        public async Task<IActionResult> GetFromExternal((string storyId = "1009351", CharacterRequestFilter filter = null))
        {
            
            using (var response = await HttpClient.GetAsync(https://localhost:5001/api/externalEndpoint))
            {

            string httprequestUrl =
                string.Format("{0}/{1}/characters", StoriesUrlSegment, storyId);

            //HttpRequest httpRequest = new HttpRequest(httprequestUrl, Method.GET);



            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, httprequestUrl);


            //request.RequestFormat = DataFormat.Json;

            HttpClient httpClient = new HttpClient/*("http://gateway.marvel.com/").BaseAddress*/();

            System.Uri uri = new System.Uri("http://gateway.marvel.com/");

            httpClient.BaseAddress = uri;


            //restClient.Execute(request);

            //restClient.DefaultParameters

            httpClient.DefaultRequestHeaders
.Accept
.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

            request.AddHeader("Content-Type", "application/json;charset=UTF-8");

            if (!response.IsSuccessStatusCode)
                    return StatusCode((int)response.StatusCode);

                var responseContent = await response.Content.ReadAsStringAsync();
                var deserializedResponse = JsonConvert.DeserializeObject<List<string>>(responseContent);

                return Ok(deserializedResponse);
            }
        }

        public async Task<ViewResult> /*RestResponse*//*RestRequest*//*CharacterResult*/ /*FindStoryCharacters(string storyId = "1009351", CharacterRequestFilter filter = null)*/FindStoryCharacters(string storyId = "1009351", CharacterRequestFilter filter = null)
        {
            // Build request url
            //
            string requestUrl =
                string.Format("{0}/{1}/characters", StoriesUrlSegment, storyId);

            RestRequest request = new RestRequest(requestUrl, Method.GET);

            request.RequestFormat = DataFormat.Json;

            // Parse filter
            //
            //ParseCharacterFilter(request, filter);

            RestClient restClient = new RestClient("http://gateway.marvel.com/");

            //HttpRequest httpRequest = new HttpRequest()

            // GET api/values/getFromExternal
            //[HttpGet, Route("getFromExternal")]
            ////public async Task<IActionResult> GetFromExternal()
            ////{
            ////    using (var response = await HttpClient.GetAsync("https://localhost:5001/api/externalEndpoint"))
            ////    {
            ////        if (!response.IsSuccessStatusCode)
            ////            return StatusCode((int)response.StatusCode);

            ////        var responseContent = await response.Content.ReadAsStringAsync();
            ////        var deserializedResponse = JsonConvert.DeserializeObject<List<string>>(responseContent);

            ////        return Ok(deserializedResponse);
            ////    }
            ////}

            // Build request url
            //
            string httprequestUrl =
                string.Format("{0}/{1}/characters", StoriesUrlSegment, storyId);

            //HttpRequest httpRequest = new HttpRequest(httprequestUrl, Method.GET);

            

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, httprequestUrl);


            request.RequestFormat = DataFormat.Json;

            HttpClient httpClient = new HttpClient/*("http://gateway.marvel.com/").BaseAddress*/();

            System.Uri uri = new System.Uri("http://gateway.marvel.com/");

            httpClient.BaseAddress = uri;


            //restClient.Execute(request);

            //restClient.DefaultParameters

            httpClient.DefaultRequestHeaders
.Accept
.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

            request.AddHeader("Content-Type", "application/json;charset=UTF-8");



            RestResponse restResponse = (RestResponse)restClient.Execute(request);

            //[HttpPost]
            //[Route("AddorUpdatePersonalInfo")]
            //public async Task<HttpResponseMessage> AddorUpdatePersonalInfo(/*[FromBody] PersonalInfo personalinfo*/)
            //{
            //    try
            //    {
            //        var result = await this._Personalinforepository.AddorUpdatePersonalInfo(personalinfo);
            //        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            //        return response;
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            //    }
            //}

            /*(await)*//*c */
            /*Microsoft.AspNetCore.Http.HttpResponse httpResponse*/ /*Task*/
            //Microsoft.AspNetCore.Http.HttpResponse httpResponse = await (Microsoft.AspNetCore.Http.HttpResponse)httpClient.GetAsync(httpClient.BaseAddress/*uri*//*httpRequestMessage.ToString()*//*httpRequest.ToString()*/);

            //response.Headers.Add("Content-Type", "application/json;charset=UTF-8");

            //    return await Task<HttpResponseMessage>.Factory.StartNew(() =>
            //{
            //   return Request.CreateResponse(HttpStatusCode.OK, data);
            //});

            //var data = 

            //async Task<Microsoft.AspNetCore.Http.HttpResponseMessage> Get()
            //{
            //    var data = await httpClient.GetAsync(httpClient.BaseAddress);
            //    return /*httpRequestMessage.Headers */httpResponse;/*(HttpStatusCode.OK, data);*/
            //}

            var content = "Content-Type";
            var response = new HttpResponseMessage
            {
                Content = new StringContent(content)
            };
            response.Content.Headers.Add(@"Content-Length", content.Length.ToString());

            //httpResponse.Headers.Add(  HttpHeader header = "Content-Type", Value = "application/json;charset=UTF-8" );

            //httpResponse.Headers.Add(Name = "Content-Type", Value = "application/json;charset=UTF-8");


            //ViewBag == httpResponse;


            ViewBag.Message = httpResponse;

            return View(/*<Task>*//*httpResponse*/);

            //_ = response.Content;


            /*return*/ /*Execute*//*<CharacterResult>*//*(*//*(RestRequest)*//*Task*//*)*/;
        }

        public IActionResult Index(/*RestResponse restResponse*//*RestRequest request*//*NameViewModel postdata*/)
        {

            const string apiKey = "1f8c669bfb6d6b86aa65400c8f3ad03d";
            const string privateKey = "b7e37b0815b570c2f84f0267060b0637698ed06a";

            var client = new MarvelRestClient(apiKey, privateKey);
            //List<ResultViewModel> results = null;
            List<CharactersInResultViewModel> results = null;
            List<CharactersInResultViewModel> resultsCharactersInAStory = null;



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
            //    results =
            //    response.Data.Results.Select(res =>
            //        new CharactersInResultViewModel { Id = res.Id, Description = res.Description, Name = res.Name, Url = res.Urls.FirstOrDefault(t => t.Type == "detail").URL }).ToList();
            //}


            results =
            response.Data.Results.Select(res =>
                new CharactersInResultViewModel { StoryID = /*res.Stories.Items.Equals(*/"1009351"/*).ToString()*/,/**StoryID = res.Stories. */Id = res.Id, Description = res.Description, Name = res.Name, Url = res.Urls.FirstOrDefault(t => t.Type == "detail").URL }).ToList();



            //            else
            //            {

            //                    if (response.Code == "200")
            //            {
            //            results =
            //            response.Data.Results.Select(res =>
            //                new CharactersInResultViewModel { Id = res.Id, Description = res.Description, Name = res.Name, Url = res.Urls.FirstOrDefault(t => t.Type == "detail").URL
            //    }).ToList();
            //}


            //results =
            //            response.Data.Results.Select(res =>
            //                new CharactersInResultViewModel { StoryID = /*res.Stories.Items.Equals(*/"1009351"/*).ToString()*/,/**StoryID = res.Stories. */Id = res.Id, Description = res.Description, Name = res.Name, Url = res.Urls.FirstOrDefault(t => t.Type == "detail").URL }).ToList();


            List<ResultViewModel> realresults = new List<ResultViewModel>();

            //ResultViewModel realresults; 


            realresults =
            response.Data.Results.Select(res =>
                new ResultViewModel { Id = res.Id, Description = res.Description, Name = res.Name, Url = res.Urls.FirstOrDefault(t => t.Type == "detail").URL }).ToList();

            realresults.FirstOrDefault();



            //else
            //{

            //if (response.Code == "200")
            //{
            //results =
            //response.Data.Results.Select(res =>
            //    new ResultViewModel { Id = res.Id, Description = res.Description, Name = res.Name, Url = res.Urls.FirstOrDefault(t => t.Type == "detail").URL }).ToList();
            //    }


            //results =
            //response.Data.Results.Select(res =>
            //    new CharactersInResultViewModel { StoryID = /*res.Stories.Items.Equals(*/"1009351"/*).ToString()*/,/**StoryID = res.Stories. */Id = res.Id, Description = res.Description, Name = res.Name, Url = res.Urls.FirstOrDefault(t => t.Type == "detail").URL }).ToList();


            //}
            //else
            //{

            FindStoryCharacters();

            //ViewBag.Message = (List<CharactersInResultViewModel>)request;

            /*ViewBag.Message =*/ /*(List<CharactersInResultViewModel>)*//*request;*/

            /* ViewBag.Message =*/ /*(List<CharactersInResultViewModel>)*//*restResponse;*/


            //ViewBag.Message = results;





            //var comicFilter = new ComicRequestFilter { TitleStartsWith = "hulk" };
            //comicFilter.OrderBy(OrderResult.NameAscending);
            //comicFilter.Limit = 40;
            ////comicFilter.Limit = 1;

            //var comicFilterresponse = client.FindComics(comicFilter);

            ////if (response.Code == "200")
            ////{
            //results =
            //response.Data.Results.Select(res =>
            //    new CharactersInResultViewModel { /*Characters = Marvel.Api.Model.DomainObjects.Story.*/ Id = res.Id, Description = res.Description, Name = res.Name, Url = res.Urls.FirstOrDefault(t => t.Type == "detail").URL }).ToList();
            ////}
            //var firstResultDescription = results.FirstOrDefault();

            //var characterList = 

            //var characterList = firstResultDescription.Description.

            //var Filter = new StoryRequestFilter { };
            //Filter.OrderBy(OrderResult.NameAscending);
            //Filter.Limit = 40;
            ////filter.Limit = 1;

            //StoryResult storyFilterresponse = client.FindStory("1009351");  /*client.FindStoryCharacters("1009351");*/

            //resultsCharactersInAStory =
            //storyFilterresponse.Data.Results.Select(res =>
            //    new CharactersInResultViewModel { /*Characters = res.Stories., */Id = res.Id, Description = res.Description/*, Name = res.Name, Url = res.Urls.FirstOrDefault(t => t.Type == "detail").URL */}).ToList();
            ////    }



            //storyFilterresponse.Data.Results.

            //resultsCharactersInAStory =
            //storyFilterresponse.Data.Results.Select(res =>
            //    new CharactersInResultViewModel { /*Characters = res.Stories., */Id = res.Id, Description = res.Description/*, Name = res.Name, Url = res.Urls.FirstOrDefault(t => t.Type == "detail").URL */}).ToList();
            ////    }

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

            var storyFilterresponseCharacterList = charactersResults;

            var baseAddress = new Uri("http://importmarvel.com/");

            using (var httpClient = new HttpClient
            {
                BaseAddress = baseAddress
            })
            {

                using (var allCharactersInAStory = /*await */httpClient.GetAsync("api/characters"))
                {

                    string allCharactersInAStoryData = allCharactersInAStory.Result.ToString();

                    ViewBag.Message = allCharactersInAStoryData;

                    return View(allCharactersInAStoryData);

                }

                //ViewBag.Message = allCharactersInAStoryData;

                //ViewBag.Message = realresults;

                //return View(allCharactersInAStoryData);

                //return View(realresults); 





                //ViewBag.Message = results;


                //return View(results); 



                //ViewBag.Message = resultsCharactersInAStory;


                //return View(resultsCharactersInAStory);






                //return View(storyFilterresponse);


                //ViewBag.Message = storyFilterresponseCharacterList;

                //return Json(storyFilterresponseCharacterList);

                //return View("Index", restResponse);

                //return View(storyFilterresponseCharacterList);

                //return Json(results);
















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

            }
        }

                [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
                public IActionResult Error()
                {
                    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                }
            }
        }
    
