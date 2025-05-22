using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel
{
    public class PredictionViewModel
    {
        [Required(ErrorMessage = "Fecha es requerida")]
        public required List<DateTime> Date { get; set; }

        [Required(ErrorMessage = "Valor es requerido")]
        public required List<double> Valor { get; set; }
    }
}
