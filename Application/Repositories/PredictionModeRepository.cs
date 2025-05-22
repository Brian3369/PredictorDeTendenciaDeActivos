using Application.Dtos;

namespace Application.Repositories
{
    public class PredictionModeRepository
    {
        private static PredictionModeRepository _instance;
        private static readonly object _lock = new object();

        public PredictionModeDto Value { get; private set; }

        private PredictionModeRepository()
        {
            Value = new PredictionModeDto(); // Inicializa con un objeto por defecto
        }

        public static PredictionModeRepository Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new PredictionModeRepository();
                    return _instance;
                }
            }
        }

        public void SetValue(PredictionModeDto dto)
        {
            Value = dto;
        }
    }

}