using MicroCredit.Domain.Entities;

namespace MicroCredit.Application.Services
{
    public interface IUserService
    {
        User GetDigitalKey(string nif);
    }
}
