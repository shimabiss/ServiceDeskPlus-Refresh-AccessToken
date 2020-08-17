using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ServiceDeskPlus_Refresh_AccessToken.Domains.Entities;
using ServiceDeskPlus_Refresh_AccessToken.UseCases;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServiceDeskPlus_Refresh_AccessToken.Domains
{
    /// <summary>
    /// アクセストークンをリフレッシュ
    /// </summary>
    public class RefreshAccessTokenInteractor : IRefreshAccessTokenUseCase
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// appsettings.jsonからトークンのリフレッシュに必要な環境変数を取得
        /// </summary>
        /// <param name="configuration"></param>
        public RefreshAccessTokenInteractor(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// アクセストークンをリフレッシュ
        /// </summary>
        /// <returns></returns>
        public async Task<RefreshAccessTokenResponse> ExecuteAsync()
        {
            using (var client = new HttpClient())
            {
                var url = "https://accounts.zoho.com/oauth/v2/token";
                var parameters = new Dictionary<string, string>()
                {
                    {"client_id", _configuration["ServiceDeskPlusClientId"] },
                    {"client_secret", _configuration["ServiceDeskPlusClientSecret"] },
                    {"grant_type", _configuration["ServiceDeskPlusGrantType"] },
                    {"redirect_url", _configuration["ServiceDeskPlusRedirectUri"] },
                    {"refresh_token", _configuration["ServiceDeskPlusRefreshToken"]},
                    {"scope", _configuration["ServiceDeskPlusScope"] }
                };
                var encodedContent = await new FormUrlEncodedContent(parameters).ReadAsStringAsync();
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url + "?" + encodedContent);

                var result = await client.SendAsync(httpRequestMessage);
                var response = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<RefreshAccessTokenResponse>(response);
            }
        }
    }
}