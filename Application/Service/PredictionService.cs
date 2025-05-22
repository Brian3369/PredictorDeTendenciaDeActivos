using Application.Dtos;
using Application.Repositories;

namespace Application.Service
{
    public class PredictionService
    {
        public void AddDatos(PredictionDataDto data)
        {
            PredictionRepository.Instance.productDto = data;
        }

        public PredictionDataDto GetDatos()
        {
            return PredictionRepository.Instance.productDto;
        }
    }
}
