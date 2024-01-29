using ChoiceDinner.Application.Features.Authentications.Commands;
using ChoiceDinner.Application.Features.Authentications.Queries;
using ChoiceDinner.Contracts.Authentications;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace ChoiceDinner.Api.Controllers;


[Route("auth")]
public class AuthenticationController : BaseApiController
{

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request) {
        
        var command = new Register.Command(request.Email, request.Password, request.FirstName,request.MiddleName, request.LastName);
        var results = await Mediator.Send(command);
        return HandleResult(results);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request) {

        var query = new Login.Query(request.Email, request.Password);
        var results = await Mediator.Send(query);
        return HandleResult(results);
    }
}