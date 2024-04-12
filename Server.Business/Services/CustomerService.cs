using Server.Core.DTOs;
using Server.Core.Responses;
using Server.Data.Repositories.Contracts;

namespace Server.Business.Services
{
    public class CustomerService
    {
        #region Properties
        private readonly ICustomerRepository _customerRepository;
        #endregion

        #region Methods
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<GeneralResponse> CreateAsync(Register user)
        {
            if (user is null)
                return new GeneralResponse(false, "Invalid Fields");

            // Register Customer
            var response = await _customerRepository.CreateAsync(user);
            return response;
        }
        public async Task<LoginResponse> SignInAsync(Login user)
        {
            if (user is null)
                return new LoginResponse(false, "Invalid Fields");

            // Login Customer
            var response = await _customerRepository.SignInAsync(user);
            return response;
        }
        public async Task<LoginResponse> RefreshTokenAsync(RefreshToken token)
        {
            if (token is null)
                return new LoginResponse(false, "Invalid Fields");

            // Refresh Token
            var response = await _customerRepository.RefreshTokenAsync(token);
            return response;
        }
        #endregion
    }
}
