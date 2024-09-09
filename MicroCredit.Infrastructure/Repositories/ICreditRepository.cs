using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroCredit.Infrastructure.Repositories
{
    public interface ICreditRepository
    {
        decimal CalculateLimit(decimal rendimentoMensal);
    }
}
