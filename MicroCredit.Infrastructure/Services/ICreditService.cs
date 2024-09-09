using MicroCredit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroCredit.Infrastructure.Services
{
    public interface ICreditService
    {
        decimal GetCreditLimit(decimal rendimentoMensal);
    }
}
