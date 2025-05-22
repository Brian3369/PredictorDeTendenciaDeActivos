using Application.Dtos;
using Application.Repositories;

namespace Application.Service
{
    public class PredictionModeService
    {
        public void AddMode(PredictionModeDto modo)
        {
            PredictionModeRepository.Instance.SetValue(modo);
        }
        public PredictionModeDto GetMode()
        {
            return PredictionModeRepository.Instance.Value;
        }
    }
}
