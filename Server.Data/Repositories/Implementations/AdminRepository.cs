using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Server.Core.DTOs;
using Server.Core.Entities;
using Server.Core.Responses;
using Server.Data.DBContexts;
using Server.Data.Repositories.Contracts;
using Server.Utilities.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Server.Data.Repositories.Implementations
{
    public class AdminRepository(IOptions<JwtSection> config, ApplicationDbContext applicationDbContext) : IAdminRepository
    {
        #region Methods
        public async Task<GeneralResponse> CreateAsync(Register user)
        {
            if (user is null)
                return new GeneralResponse(false, "Fields are required!");

            // Check if user already exists
            var checkUser = await FindUserByEmail(user.Email!);
            if (checkUser != null)
                return new GeneralResponse(false, "User already exists!");

            // Register User
            var adminUser = await AddToDatabase(new Admin()
            {
                Name = $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password)
            });

            return new GeneralResponse(true, "Account created successfully");
        }
        public async Task<LoginResponse> SignInAsync(Login user)
        {
            if (user is null)
                return new LoginResponse(false, "Invalid fields!");

            // Check if user exists
            var adminUser = await FindUserByEmail(user.Email!);
            if (adminUser is null)
                return new LoginResponse(false, "User does not exists");

            // Verify Password
            if (!BCrypt.Net.BCrypt.Verify(user.Password, adminUser.Password))
                return new LoginResponse(false, "Invalid Credentials");

            string jwtToken = GenerateToken(adminUser);

            return new LoginResponse(true, "Login Successfull!", jwtToken);
        }
        #endregion

        #region Util Method
        private string GenerateToken(Admin user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Value.Key!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("NameIdentifier", user.Id.ToString()),
                new Claim("Name", user.Name!),
                new Claim("Email", user.Email!)
            };
            var token = new JwtSecurityToken(
                    issuer: config.Value.Issuer!,
                    audience: config.Value.Audience!,
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private async Task<Admin> FindUserByEmail(string Email) =>
            await applicationDbContext.Admins.FirstOrDefaultAsync(_ => _.Email!.ToLower()!.Equals(Email!.ToLower()));
        private async Task<T> AddToDatabase<T>(T model)
        {
            var result = applicationDbContext.Add(model!);
            await applicationDbContext.SaveChangesAsync();
            return (T)result.Entity;
        }
        #endregion
    }
}
