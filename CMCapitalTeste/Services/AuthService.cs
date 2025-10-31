using BCrypt.Net;
using CMCapitalAvaliacao.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using CMCapitalAvaliacao.Models;
using CMCapitalAvaliacao.Repositories.Interfaces;
using CMCapitalAvaliacao.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CMCapitalAvaliacao.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _userRepo;
        private readonly IConfiguration _config;

        public AuthService(IUsuarioRepository userRepo, IConfiguration config)
        {
            _userRepo = userRepo;
            _config = config;
        }

        public string Login(string username, string password)
        {
            var user = _userRepo.GetByUsername(username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                throw new UnauthorizedAccessException("Usuário ou senha inválidos.");

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public void Register(string username, string password, string role = "User")
        {
            var existing = _userRepo.GetByUsername(username);
            if (existing != null)
                throw new Exception("Usuário já existe.");

            var usuario = new UsuarioBO
            {
                Username = username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                Role = role
            };

            _userRepo.AddOrUpdate(usuario, null);
        }
    }
}
