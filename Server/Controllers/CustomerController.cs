using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Business.Services;
using Server.Core.DTOs;
using Server.Core.Responses;

namespace Server.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService customerService;
        public CustomerController(CustomerService _customerService)
        {
            customerService = _customerService;
        }

        [HttpPost("register")]
        public async Task<GeneralResponse> CreateAsync(Register user)
        {
            try
            {
                var response = await customerService.CreateAsync(user);
                return response;
            }
            catch (Exception ex)
            {
                return new GeneralResponse(false, ex.Message);
            }
        }
        [HttpPost("login")]
        public async Task<LoginResponse> SignInAsync(Login user)
        {
            try
            {
                var response = await customerService.SignInAsync(user);
                return response;
            }
            catch(Exception ex)
            {
                return new LoginResponse(false, ex.Message);
            }
        }
        [HttpPost("refresh-token")]
        public async Task<LoginResponse> RefreshTokenAsync(RefreshToken token)
        {
            try
            {
                var response = await customerService.RefreshTokenAsync(token);
                return response;
            }
            catch(Exception ex)
            {
                return new LoginResponse(false, ex.Message);
            }
        }
    }
}
