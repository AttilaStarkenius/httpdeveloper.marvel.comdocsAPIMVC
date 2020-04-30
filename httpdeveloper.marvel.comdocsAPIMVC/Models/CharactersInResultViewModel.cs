using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace httpdeveloper.marvel.comdocsAPIMVC.Models
{
    public class CharactersInResultViewModel
    {
        public List<ResultViewModel> Characters;
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }        
    }
}
