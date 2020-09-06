using iTunesSearch.DTO;
using iTunesSearch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                //return new HttpUnauthorizedResult("You are not authorized. Please login before searching.");
                //return RedirectToAction("/Account/Login");
                //return Json(new { responseCode = 401, responseText = "You are not authorized. Please login before searching." });
            }

            if (string.IsNullOrWhiteSpace(keyword))
                return PartialView("_Movie", new List<Movie>());

            ApiService apiService = new ApiService();
            string result = apiService.CallApi(keyword);

            var jsonConverterService = new JsonConverterService();
            var list = jsonConverterService.ConvertToMovieList(result);
            return PartialView("_Movie", list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}