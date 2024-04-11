using Server.Core.DTOs;
using Server.Core.Responses;
using Server.Data.Repositories.Contracts;

namespace Server.Business.Services
{
    public class AdminService
    {
        #region Properties
        private readonly IAdminRepository _adminRepository;
        #endregion

        #region Methods
        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository ?? throw new ArgumentNullException(nameof(adminRepository));
        }

        public async Task<GeneralResponse> CreateAsync(Register user)
        {
            if (user == null)
                return new GeneralResponse(false, "Invalid Fields");

            // Create Admin User
            var response = await _adminRepository.CreateAsync(user);
            return response;
        }

        public async Task<LoginResponse> SignInAsync(Login user)
        {
            if (user == null)
                return new LoginResponse(false, "Invalid Fields");

            // Login Admin User
            var response = await _adminRepository.SignInAsync(user);
            return response;
        }
        #endregion
    }
}
