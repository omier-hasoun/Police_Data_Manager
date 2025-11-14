using API.Common;
using API.Requests;
using API.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller;

[Route("api/token")]
[ApiController]
public class TokenController(ITokenGenerator tokenGenerator) : ControllerBase
{

    [HttpPost("generate")]
    public IActionResult GenerateToken(GenerateTokenRequest request)
    {

        TokenResponse response = tokenGenerator.Generate(request);

        return Ok(response);
    }

}
