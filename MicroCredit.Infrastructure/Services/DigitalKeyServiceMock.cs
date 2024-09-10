using MicroCredit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroCredit.Infrastructure.Services
{
    public class DigitalKeyServiceMock : IDigitalKeyService
    {
        public DigitalKeyServiceMock() { }

        public User GetUserData(string nif)
        {
            // Mock
            return new User
            {
                Nome = "Zé Manel",
                NIF = nif,
                Morada = "Rua Exemplo",
                Income = 2000
            };
        }
    }
}
