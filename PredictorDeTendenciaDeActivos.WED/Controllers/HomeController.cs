using Application.Dtos;
using Application.Repositories;
using Application.Service;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace PredictorDeTendenciaDeActivos.WED.Controllers
{
    public class HomeController : Controller
    {
        private readonly PredictionService _predictionService;
        private readonly PredictionModeService _predictionModeService;
        public HomeController()
        {
            _predictionService = new PredictionService();
            _predictionModeService = new PredictionModeService();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(PredictionViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var predictiondto = new PredictionDto();
            predictiondto.Date = data.Date;
            predictiondto.Valor = data.Valor;

            var mode = PredictionModeRepository.Instance.Value.PredictionModes;
            var resultado = _predictionService.calcular(predictiondto, mode);


            ViewBag.Resultado = resultado;

            return View(data);
        }
    }
}
