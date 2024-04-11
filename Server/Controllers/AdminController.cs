using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Business.Services;
using Server.Core.DTOs;
using Server.Core.Responses;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        #region Properties
        private readonly AdminService adminService;
        #endregion

        #region Methods
        public AdminController(AdminService _adminService)
        {
            adminService = _adminService;
        }

        [HttpPost("register")]
        public async Task<GeneralResponse> CreateAsync(Register user)
        {
            try
            {
                var response = await adminService.CreateAsync(user);
                return response;
            }
            catch(Exception ex)
            {
                return new GeneralResponse(false, ex.Message);
            }
        }
        [HttpPost("login")]
        public async Task<LoginResponse> SignInAsync(Login user)
        {
            try
            {
                var response = await adminService.SignInAsync(user);
                return response;
            }
            catch (Exception ex)
            {
                return new LoginResponse(false, ex.Message);
            }
        }
        #endregion
    }
}
