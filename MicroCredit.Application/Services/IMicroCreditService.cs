
using MicroCredit.Domain.Entities;

namespace MicroCredit.Application.Services
{
    public interface IMicroCreditService
    {
        decimal GetCreditLimit(decimal income);

        bool ApproveCredit(User user);
    }
}
