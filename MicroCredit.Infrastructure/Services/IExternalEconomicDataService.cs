using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroCredit.Infrastructure.Services
{
    public interface IExternalEconomicDataService
    {
        decimal GetInflationRate();
        decimal GetUnemploymentRate();
    }
}
