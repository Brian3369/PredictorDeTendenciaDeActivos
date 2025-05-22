using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using PredictorDeTendenciaDeActivos.WED.Models;
using System.Diagnostics;

namespace PredictorDeTendenciaDeActivos.WED.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AddPreditionData data)
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
