using iTunesSearch.DTO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace iTunesSearch.Services
{
    public class JsonConverterService
    {
        public List<Movie> ConvertToMovieList(string jsonResult)
        {
            dynamic jsonArray = JsonConvert.DeserializeObject<dynamic>(jsonResult);

            return JsonConvert.DeserializeObject<List<Movie>>(jsonArray.results.ToString());
        }
    }
}