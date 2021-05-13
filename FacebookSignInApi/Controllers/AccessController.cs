using FacebookSignInApi.Models.Facebook.Requests;
using FacebookSignInApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace FacebookSignInApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private IFacebookService _facebookService;
        private readonly IOptions<AppSettings> _settings;

        public AccessController(
            IOptions<AppSettings> settings,
            IFacebookService facebookService)
        {
            _settings = settings;
            _facebookService = facebookService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("signin-facebook")]
        public async Task<string> SignInFacebook(FacebookSignInRequest request)
        {
            try
            {
                var inputToken = request.AccessToken;
                var accessToken = $"{_settings.Value.FacebookSettings.AppID}|{_settings.Value.FacebookSettings.AppSecret}";
                var result = await _facebookService.DebugToken(inputToken, accessToken);

                // Now we are sure the token is valid for our app, however we must verify if the user from the request is the same as the user within the token.
                if (result.data.is_valid == true && result.data.user_id == request.UserID)
                {
                    // We should now fetch the user's claims and provide her/him with an Access Token.
                    return "OK";
                }
                else
                    throw new Exception("Token is not valid");
            }
            catch (Exception ex)
            {
                return $"ERROR: {ex.Message}";
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("signout-facebook")]
        public async Task<string> SignOutFacebook() //should actually receive a request with the access token and the user Id.
        {
            try
            {
                // Proceed to take any actions if needed such as disabling or deleting the user's refresh token.
                return "OK";
            }
            catch (Exception ex)
            {
                return $"ERROR: {ex.Message}";
            }
}
    }
}
