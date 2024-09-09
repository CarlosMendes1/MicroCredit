using MicroCredit.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroCredit.Infrastructure.Services
{
    public class CreditService : ICreditService
    {
        private readonly ICreditRepository _creditRepository;

        public CreditService(ICreditRepository creditRepository)
        {
            _creditRepository = creditRepository;
        }

        public decimal GetCreditLimit(decimal rendimentoMensal)
        {
            return _creditRepository.CalculateLimit(rendimentoMensal);
        }
    }
}
