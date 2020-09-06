using iTunesSearch.DTO;
using iTunesSearch.Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace iTunesSearch.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string keyword)
        {
            if (!User.Identity.IsAuthenticated)
            {
                throw new UnauthorizedAccessException();
            }

            if (string.IsNullOrWhiteSpace(keyword))
                return PartialView("_Movie", new List<Movie>());

            ApiService apiService = new ApiService();
            string result = apiService.CallApi(keyword);

            var jsonConverterService = new JsonConverterService();
            var list = jsonConverterService.ConvertToMovieList(result);
            return PartialView("_Movie", list);
        }
    }
}