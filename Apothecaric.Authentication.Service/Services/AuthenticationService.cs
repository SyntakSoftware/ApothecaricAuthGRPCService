using Apothecaric.Authentication.Service.Protos;
using Grpc.Core;
using System.Threading.Tasks;

namespace Apothecaric.Authentication.Service.Services
{
    public class AuthenticationService : Protos.Authentication.AuthenticationBase
    {
        public override Task<AuthenticatedUserResponse> CreateToken(LoginRequest request, ServerCallContext context)
        {
            return Task.FromResult(new AuthenticatedUserResponse
            {
                AuthToken = "12345678987654321",
                RefreshToken = "222333444555",
                FirstName = "Eric",
                LastName = "Smasal"
            });
        }

        public override Task<AuthenticatedUserResponse> RefreshToken(RefreshTokenRequest request, ServerCallContext context)
        {
            return Task.FromResult(new AuthenticatedUserResponse
            {
                AuthToken = "98765432123456789",
                RefreshToken = "555444333222",
                FirstName = "Eric",
                LastName = "Smasal"
            });
        }
    }
} 
