using Marvel.Api.Model.Lists;
using Marvel.Api.Model.Summaries;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace httpdeveloper.marvel.comdocsAPIMVC.Models
{
    public class CharactersInResultViewModel
    {
        RestRequest request { get; set; }
        public string StoryID { get; set; }
        public CharacterList Characters { get; set; }

        public List<ResultViewModel> CharactersInTheStory;
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }        
    }
}
