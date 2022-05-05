using Cinemanjaro.Common.Authentication;
using Cinemanjaro.Users.Core.DataAccessLayer.Repositories;
using Cinemanjaro.Users.Core.Entities;
using Cinemanjaro.Users.Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cinemanjaro.Users.Core.Services
{
    public class UsersService : IUsersService
    {
        private readonly IPasswordHasher<User> _hasher;
        private readonly IUsersRepository _usersRepo;
        private readonly AuthenticationSettings _settings;

        public UsersService(IPasswordHasher<User> passwordHasher, IUsersRepository usersRepo, AuthenticationSettings settings)
        {
            _hasher = passwordHasher;
            _usersRepo = usersRepo;
            _settings = settings;
        }

        public async Task RegisterUser(string email, string password)
        {
            var existingUser = await _usersRepo.Get(email);
            if (existingUser != null)
                throw new EmailTakenException();

            var user = new User() { Email = email };

            var hash = _hasher.HashPassword(user, password);
            user.ApplyPasswordHash(hash);

            await _usersRepo.Create(user);
        }
        public async Task<string> Login(string email, string password)
        {
            var user = await _usersRepo.Get(email);

            VerifyUser(user, password);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email)
            };

            var token = GenerateToken(claims, email, password);

            var output = new JwtSecurityTokenHandler().WriteToken(token);

            return output;
        }

        private void VerifyUser(User user, string providedPassword)
        {
            if (user == null)
                throw new UserNotExistException();

            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, providedPassword);
            if (result == PasswordVerificationResult.Failed)
                throw new InvalidPasswordException();
        }

        private JwtSecurityToken GenerateToken(List<Claim> claims, string email, string password)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_settings.JwtExpireDays);

            return new JwtSecurityToken(_settings.JwtIssuer, _settings.JwtIssuer, claims, expires: expires, signingCredentials: cred);
        }
    }
}
