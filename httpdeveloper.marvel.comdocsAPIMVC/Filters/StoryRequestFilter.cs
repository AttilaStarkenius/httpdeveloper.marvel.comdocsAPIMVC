using Marvel.Api.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace httpdeveloper.marvel.comdocsAPIMVC.Filters
{
    public class StoryRequestFilter : BaseFilter
    {
        //public StoryRequestFilter();

        private readonly List<int> _characters;
        private readonly List<int> _series;
        private readonly List<int> _comics;
        private readonly List<int> _creators;
        private readonly List<int> _events;

        public StoryRequestFilter()
        {
            _comics = new List<int>();
            _series = new List<int>();
            _creators = new List<int>();
            _characters = new List<int>();
            _events = new List<int>();
        }


        public DateTime? ModifiedSince { get; set; }
        //public string Comics { get; }
        public string Series { get; }
        public string Creators { get; }
        public string Characters { get; }
        public string Events { get; }


        // <summary>
        /// Return only characters which appear in the specified comics 
        /// (accepts a comma-separated list of ids).
        /// </summary>
        public string Comics
        {
            get
            {
                if (_comics.Count == 0)
                    return string.Empty;

                return string.Join(",", _comics.ToArray());
            }
        }





        //public void AddCharacter(int id);
        //public void AddComic(int id);
        //public void AddCreator(int id);
        //public void AddEvent(int id);
        //public void AddSeries(int id);


    }
}
