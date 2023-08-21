using IkıncıDereceDenklemQueryString.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IkıncıDereceDenklemQueryString.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult SolveEquation(double a, double b, double c)
        {
            if (a == 0)
            {
                ViewBag.ErrorMessage = "a katsayısı sıfır olamaz.";
                return View("Index");
            }

            double delta = b * b - 4 * a * c;

            if (delta < 0)
            {
                ViewBag.ErrorMessage = "Denklemin gerçel kökü yok.";
                return View("Index");
            }

            double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
            double x2 = (-b - Math.Sqrt(delta)) / (2 * a);

            ViewBag.SolutionMessage = $"Denklemin kökleri: x1 = {x1}, x2 = {x2}";
            return View("Index");
        }
    }
}