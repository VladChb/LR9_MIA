using Microsoft.AspNetCore.Mvc;
using BookHubAPI.Models;
using BookHubAPI.Services;

namespace BookHubAPI.Controllers
{
    [ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly MemberService _memberService;
    private readonly TokenService _tokenService;

    public AuthController(MemberService memberService, TokenService tokenService)
    {
        _memberService = memberService;
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var members = await _memberService.GetAllAsync();
        var member = members.FirstOrDefault(m => m.Email == request.Email);

        if (member == null)
            return Unauthorized("Користувача не знайдено");

        if (member.Password != request.Password)
            return Unauthorized("Невірний пароль");

        var token = _tokenService.GenerateToken(member);
        return Ok(new { token });
    }
}

}
