using FacebookSignInApi.Services.Facebook.Responses.DebugToken;
using System.Threading.Tasks;

namespace FacebookSignInApi.Services
{
    public interface IFacebookService
    {
        Task<DebugTokenResponse> DebugToken(string inputToken, string accessToken);
    }
}
