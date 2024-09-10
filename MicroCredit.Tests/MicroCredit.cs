using MicroCredit.API.Models;
using MicroCredit.Application.Services;
using MicroCredit.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace MicroCredit.Tests
{
    public class MicroCredit
    {
        private readonly Mock<IMicroCreditService> _mockRiskAnalysisService;
        private readonly UserCreditController _userCreditController;

        [Fact]
        public void MicroCreditRequest_ReturnsOkResult()
        {
            var customer = new User
            {
                Nome = "Zé",
                Income = 3000,
                Debt = 200,
                CreditScore = 700
            };

            // Configurar o mock para retornar um resultado aprovado
            _mockRiskAnalysisService.Setup(service => service.ApproveCredit(customer))
                .Returns(true);

            // Act
            var result = _userCreditController.RequestMicroCredit(customer);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<RequestMicroCreditResult>(okResult.Value);
            Assert.True(returnValue.Aprroved);
            Assert.Equal(5000, returnValue.CreditLimit);
        }

        [Fact]
        public void MicroCreditRequest_ReturnsBadResult()
        {
            var customer = new User
            {
                Nome = "Maria",
                Income = 800,
                Debt = 600,
                CreditScore = 500
            };

            // Configurar o mock para retornar um resultado aprovado
            _mockRiskAnalysisService.Setup(service => service.ApproveCredit(customer))
                .Returns(false);

            // Act
            var result = _userCreditController.RequestMicroCredit(customer);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<RequestMicroCreditResult>(badRequestResult.Value);
            Assert.False(returnValue.Aprroved);
            Assert.Equal(1000, returnValue.CreditLimit);
        }
    }
}