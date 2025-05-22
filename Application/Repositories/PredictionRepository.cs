using Application.Dtos;

namespace Application.Repositories
{
    public sealed class PredictionRepository
    {
        private PredictionRepository() { }
        public static PredictionRepository Instance { get; set; } = new();
        public PredictionDataDto productDto { get; set; } = new()
        {
            Date = new(),
            Valor = new()
        };
    }
}

