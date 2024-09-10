using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroCredit.Infrastructure.Services;

namespace MicroCredit.Infrastructure.ExternalServices
{
    public class ExternalEconomicDataService : IExternalEconomicDataService
    {
        // Mock
        public decimal GetInflationRate()
        {
            return 2.5M;
        }

        public decimal GetUnemploymentRate()
        {
            return 5.8M;
        }
    }
}

