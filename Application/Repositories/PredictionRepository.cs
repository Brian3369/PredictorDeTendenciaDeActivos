using Application.Dtos;

namespace Application.Repositories
{
    public sealed class PredictionRepository
    {
        private PredictionRepository() { }
        public static PredictionRepository Instance { get; set; } = new();
        public PredictionListDto productListDto { get; set; } = new()
        {
            PredictionsData = new()
        };
    }
}

