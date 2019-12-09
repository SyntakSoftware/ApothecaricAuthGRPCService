using Apothecaric.Authentication.Api.Models;
using Apothecaric.Authentication.Service.Protos;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Apothecaric.Authentication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        [Route("Token")]
        public async Task<IActionResult> CreateToken([FromBody] LoginViewModel login)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Service.Protos.Authentication.AuthenticationClient(channel);

            var request = new LoginRequest
            {
                Email = login.Email,
                Password = login.Password
            };

            var response = await client.CreateTokenAsync(request);

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Token/Refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] UserViewModel user)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Service.Protos.Authentication.AuthenticationClient(channel);

            var request = new RefreshTokenRequest
            {
                AuthToken = user.AuthToken,
                RefreshToken = user.RefreshToken,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            var response = await client.RefreshTokenAsync(request);

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}