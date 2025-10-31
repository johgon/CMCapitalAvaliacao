using CMCapitalAvaliacao.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CMCapitalAvaliacao.Services.Interfaces;
namespace CMCapitalAvaliacao.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("register")]
        public IActionResult Register(string username, string password, string role = "User")
        {
            _auth.Register(username, password, role);
            return Ok("Usuário registrado com sucesso.");
        }

        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            var token = _auth.Login(username, password);
            return Ok(new { token });
        }
    }
}


