using MicroCredit.API.Models;
using MicroCredit.Application.Services;
using MicroCredit.Domain.Entities;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserCreditController : ControllerBase
{
    private readonly IMicroCreditService _microCreditService;
    private readonly IUserService _userService;

    public UserCreditController(IMicroCreditService microCreditService, IUserService userService)
    {
        _microCreditService = microCreditService;
        _userService = userService;
    }

    [HttpPost]
    [Route("Register")]
    public IActionResult Register(string nif)
    {
        var userData = _userService.GetDigitalKey(nif);
        if (userData == null)
            return BadRequest("Utilizador não encontrado.");

        return Ok("Utilizador registado com sucesso.");
    }

    [HttpPost]
    [Route("Request-Micro-Credit")]
    public IActionResult RequestMicroCredit(User user)
    {
        var creditLimit = _microCreditService.GetCreditLimit(user.Income);
        bool approveCredit = _microCreditService.ApproveCredit(user);

        var result = new RequestMicroCreditResult
        {
            Aprroved = approveCredit,
            CreditLimit = creditLimit 
        };

        if (!approveCredit)
            return BadRequest("Crédito não aprovado devido a alto risco.");

        return Ok(result);
    }
}
