using Application.Dtos;
using Application.Repositories;

namespace Application.Service
{
    public class PredictionService
    {
        public string CalcularSmaCrossover(PredictionDto dto)
        {
            var valores = dto.Valor;

            //if (valores.Count != 20)
            //    return "Error: Se requieren exactamente 20 valores para realizar la predicción.";

            var smaCorta = valores.TakeLast(5).Average();
            var smaLarga = valores.Average();

            string tendencia = smaCorta > smaLarga ? "Alcista" : "Bajista";

            return $"[SMA Crossover]\n" +
                   $"- SMA Corta: {smaCorta:F2}\n" +
                   $"- SMA Larga: {smaLarga:F2}\n" +
                   $"- Tendencia: {tendencia}";
        }

        public string CalcularRegresionLineal(PredictionDto dto)
        {
            var valores = dto.Valor;

            if (valores.Count != 20)
                return "Error: Se requieren exactamente 20 valores para realizar la predicción.";

            var n = valores.Count;
            var x = Enumerable.Range(1, n).Select(i => (double)i).ToList();
            var y = valores;

            var sumX = x.Sum();
            var sumY = y.Sum();
            var sumXY = x.Zip(y, (xi, yi) => xi * yi).Sum();
            var sumX2 = x.Sum(xi => xi * xi);

            double m = (n * sumXY - sumX * sumY) / (n * sumX2 - sumX * sumX);
            double b = (sumY - m * sumX) / n;
            double valorDia21 = m * 21 + b;

            string tendencia = m > 0 ? "Alcista" : "Bajista";

            return $"[Regresión Lineal]\n" +
                   $"- Pendiente (m): {m:F4}\n" +
                   $"- Intercepto (b): {b:F2}\n" +
                   $"- Valor predicho día 21: {valorDia21:F2}\n" +
                   $"- Tendencia: {tendencia}";
        }

        public string CalcularMomentumRoc(PredictionDto dto)
        {
            var valores = dto.Valor;

            if (valores.Count != 20)
                return "Error: Se requieren exactamente 20 valores para realizar la predicción.";

            int n = 5;
            List<string> resultados = new List<string>();

            for (int t = 0; t < valores.Count; t++)
            {
                if (t < n)
                {
                    resultados.Add($"t={t}, Precio={valores[t]}, ROC({n})=n/a");
                }
                else
                {
                    var roc = ((valores[t] / valores[t - n]) - 1) * 100;
                    resultados.Add($"t={t}, Precio={valores[t]}, ROC({n})={roc:F2}%");
                }
            }

            string tendencia = valores[19] > valores[14] ? "Alcista" : "Bajista";

            return "[Momentum (ROC)]\n" +
                   string.Join("\n", resultados) +
                   $"\n- Tendencia final: {tendencia}";
        }
        public string calcular(PredictionDto dto, int modo)
        {
            switch (modo)
            {
                case 1:
                    return CalcularSmaCrossover(dto);
                case 2:
                    return CalcularRegresionLineal(dto);
                case 3:
                    return CalcularMomentumRoc(dto);
                default:
                    return "Error: Modo de predicción no válido.";
            }
        }
    }
}
