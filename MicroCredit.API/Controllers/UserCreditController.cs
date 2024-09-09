using MicroCredit.Application.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserCreditController : ControllerBase
{
    private readonly IMicroCreditService _microCreditService;
    private readonly IUserService _userService;

    public UserCreditController(IMicroCreditService microCreditService)
    {
        _microCreditService = microCreditService;
    }

    [HttpPost("register")]
    public IActionResult Register(string nif)
    {
        var userData = _userService.GetDigitalKey(nif);
        if (userData == null)
            return BadRequest("Utilizador não encontrado.");

        return Ok("Utilizador registado com sucesso.");
    }

    [HttpPost("request-micro-credit")]
    public IActionResult RequestMicroCredit(string nif, decimal montante, int prazo)
    {
        var userData = _microCreditService.GetCreditLimit(montante);
        if (userData == null)
            return BadRequest("Utilizador não encontrado.");

        //var limiteCredito = _creditLimitService.GetCreditLimit(userData.RendimentoMensal);
        //var indiceRisco = _analiseRisco.CalcularIndiceRisco(0.05M, 0.03M, 700, 2000);

        //if (!_analiseRisco.AprovarCredito(indiceRisco, limiteCredito))
        //    return BadRequest("Crédito não aprovado devido a alto risco.");

        return Ok("Crédito aprovado com sucesso.");
    }
}
