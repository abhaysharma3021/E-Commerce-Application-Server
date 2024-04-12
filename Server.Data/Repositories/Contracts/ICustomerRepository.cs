using Server.Core.DTOs;
using Server.Core.Responses;

namespace Server.Data.Repositories.Contracts
{
    public interface ICustomerRepository
    {
        Task<GeneralResponse> CreateAsync(Register user);
        Task<LoginResponse> SignInAsync(Login user);
        Task<LoginResponse> RefreshTokenAsync(RefreshToken token);
    }
}
