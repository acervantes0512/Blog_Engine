using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Persistence.Repository;
using Persistence.UnitOfWork;
using Shared.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Implementations
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly JwtSettings _jwtSettings;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IPasswordHasher<User> passwordHasher, IOptions<JwtSettings> jwtSettings, IUnitOfWork unitOfWork)
        {
            _passwordHasher = passwordHasher;
            _jwtSettings = jwtSettings.Value;
            this._unitOfWork = unitOfWork;
        }

        public async Task<UserControllerDto> CreateUserAsync(User user)
        {
            user.Password = (HashPassword(user.Password));
            User createdUser = await _unitOfWork.GetRepository<User>().AddAsync(user);
            _unitOfWork.SaveChanges();
            return mapUserControllerDto(createdUser);
        }

        public async Task<UserControllerDto> GetByUsernameAsync(string username)
        {
            User user = await _unitOfWork.UserRepository.GetByUsernameAsync(username);
            return mapUserControllerDto(user);
        }

        private UserControllerDto mapUserControllerDto(User user)
        {
            return new UserControllerDto { Id = user.Id, Name = user.Name, Identification = user.Identification, Username = user.Username, RoleId = user.RoleId };
        }


        public async Task<UserDto> AuthenticateAsync(string username, string password)
        {
            User user = await _unitOfWork.UserRepository.GetByUsernameAsync(username);
            string providedPasword = HashPassword(password);

            if (user == null)
            {
                throw new AuthenticationException("Invalid credentials");
            }

            if (!providedPasword.Equals(user.Password))
            {
                throw new AuthenticationException("Invalid credentials");
            }

            var token = await GenerateJwtToken(user);

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Token = token
            };
        }

        private async Task<string> GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            Role role = await _unitOfWork.GetRepository<Role>().GetByIdAsync(user.RoleId);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    new Claim(ClaimTypes.Role, role.Name),
                }),
                Expires = DateTime.UtcNow.AddSeconds(_jwtSettings.ExpirationSeconds),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hash;
            }
        }
    }

}
