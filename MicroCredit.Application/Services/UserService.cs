using MicroCredit.Domain.Entities;
using MicroCredit.Infrastructure.Services;

namespace MicroCredit.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IDigitalKeyService _digitalKeyServiceMock;

        public UserService(IDigitalKeyService digitalKeyServiceMock)
        {
            _digitalKeyServiceMock = digitalKeyServiceMock;
        }

        public User GetDigitalKey(string nif)
        {
            return _digitalKeyServiceMock.GetUserData(nif);
        }
    }
}