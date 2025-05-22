using Application.Dtos;
using Application.Service;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace PredictorDeTendenciaDeActivos.WED.Controllers
{
    public class ModosController : Controller
    {
        private readonly PredictionModeService _predictionModeService;

        public ModosController()
        {
            _predictionModeService = new PredictionModeService();
        }

        public IActionResult Index(string? message = null)
        {
            var predictionModeDto = _predictionModeService.GetMode();
            var predictionMode = new PredictionMode
            {
                PredictionModes = predictionModeDto.PredictionModes
            };

            ViewBag.Message = message;
            return View(predictionMode);
        }

        [HttpPost]
        public IActionResult Index(PredictionMode mode)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _predictionModeService.AddMode(new PredictionModeDto()
            {
                PredictionModes = mode.PredictionModes
            });

            return RedirectToRoute(new { controller = "Modos", action = "Index", message = "Modo seleccionado"});
        }
    }
}
