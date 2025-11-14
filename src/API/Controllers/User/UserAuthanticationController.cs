using API.Common;
using API.Requests;
using API.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.User;

[ApiController]
[Route("api/[controller]")]
public class UserAuthenticationController : ControllerBase
{
    private readonly ITokenGenerator _tokenGenerator;

    public UserAuthenticationController(ITokenGenerator tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] GenerateTokenRequest request)
    {
        TokenResponse response = _tokenGenerator.Generate(request);
        return Ok(response);
    }

    [HttpPost("register")]
    [Authorize]
    public IActionResult RegisterUserAccount()
    {
        throw new NotImplementedException();
    }
}
