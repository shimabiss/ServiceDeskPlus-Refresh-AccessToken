using Microsoft.AspNetCore.Mvc;
using ServiceDeskPlus_Refresh_AccessToken.Domains.Entities;
using ServiceDeskPlus_Refresh_AccessToken.UseCases;
using System.Threading.Tasks;

namespace ServiceDeskPlus_Refresh_AccessToken.Controllers
{
    [ApiController]
    public class Controller : ControllerBase
    {
        private readonly IRefreshAccessTokenUseCase _refreshAccessTokenUseCase;

        public Controller(IRefreshAccessTokenUseCase refreshAccessTokenUseCase)
        {
            _refreshAccessTokenUseCase = refreshAccessTokenUseCase;
        }

        /// <summary>
        /// ServiceDeskPlusのアクセストークンをリフレッシュ
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/refresh")]
        public async Task<RefreshAccessTokenResponse> RefreshAccessToken()
        {
            return await _refreshAccessTokenUseCase.ExecuteAsync();
        }
    }
}
