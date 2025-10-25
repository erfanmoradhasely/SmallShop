using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmallShop.Application.Common;
using SmallShop.Contracts.Identity;
using SmallShop.Contracts.Identity.Models;
using SmallShop.Domain.Common.ValueObjects;
using SmallShop.Presentation.Api.Models;

namespace SmallShop.Presentation.Api.Controllers;


public class AuthController : ApiController
{

    private readonly IAuthService _authenticationService;

    public AuthController(IAuthService authenticationService)
    {
        this._authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public async Task<ApiResult<AuthResponse>> Login(AuthRequest request)
    {
        var authResponse = await _authenticationService.Login(request);
        return CommandResult(OperationResult<AuthResponse>.Success(authResponse));
    }

    [HttpPost("register")]
    public async Task<ApiResult<RegistrationResponse>> Register(RegistrationRequest request)
    {
        var registrationResponse = await _authenticationService.Register(request);
        return CommandResult(OperationResult<RegistrationResponse>.Success(registrationResponse));
    }
}
