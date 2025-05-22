using Application.Dtos;
using Application.Service;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using PredictorDeTendenciaDeActivos.WED.Models;
using System.Diagnostics;

namespace PredictorDeTendenciaDeActivos.WED.Controllers
{
    public class HomeController : Controller
    {
        private readonly PredictionService _predictionService;
        public HomeController()
        {
            _predictionService = new PredictionService();
        }
        public IActionResult Index()
        {
            var preditionDataDto = _predictionService.GetDatos();
            var preditionData = new AddPreditionData
            {
                Date = preditionDataDto.Date,
                Valor = preditionDataDto.Valor
            };

            return View();
        }

        [HttpPost]
        public IActionResult Index(AddPreditionData data)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _predictionService.AddDatos(new PredictionDataDto()
            {
                Date = data.Date,
                Valor = data.Valor
            });

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
    }
}
