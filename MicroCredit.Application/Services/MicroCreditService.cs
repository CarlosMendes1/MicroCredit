using MicroCredit.Domain.Entities;
using MicroCredit.Infrastructure.Services;

namespace MicroCredit.Application.Services
{
    public class MicroCreditService : IMicroCreditService
    {
        private readonly ICreditService _creditService;
        private readonly IExternalEconomicDataService _externalEconomicDataService;

        public MicroCreditService (ICreditService creditService)
        {
            _creditService = creditService;
        }

        public decimal GetCreditLimit(decimal income)
        {
            return _creditService.GetCreditLimit(income);
        }

        public bool ApproveCredit(User user)
        {
            // Get Economic Data Mocked
            var inflationRate = _externalEconomicDataService.GetInflationRate();
            var unemploymentRate = _externalEconomicDataService.GetUnemploymentRate();

            // Lógica de análise de risco com base nos dados fornecidos
            var riskScore = CalculateRiskScore(user, inflationRate, unemploymentRate);

            var result = riskScore < 0.5M;

            return result;
        }

        private decimal CalculateRiskScore(User user, decimal inflationRate, decimal unemploymentRate)
        {
            var incomeFactor = user.Income > 2000 ? 0.2M : 0.5M;
            var debtFactor = user.Debt / user.Income;
            var creditScoreFactor = 1 - (user.CreditScore / 100);
            var economicFactor = (inflationRate + unemploymentRate) / 10;

            // Calculate risk factor
            return incomeFactor + debtFactor + creditScoreFactor + economicFactor;
        }
    }
}
