using MicroCredit.Infrastructure.Services;

namespace MicroCredit.Application.Services
{
    public class MicroCreditService : IMicroCreditService
    {
        private readonly ICreditService _creditService;

        public MicroCreditService (ICreditService creditService)
        {
            _creditService = creditService;
        }

        public decimal GetCreditLimit(decimal rendimentoMensal)
        {
            return _creditService.GetCreditLimit(rendimentoMensal);
        }
    }
}
