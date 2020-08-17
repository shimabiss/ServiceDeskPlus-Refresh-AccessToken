using ServiceDeskPlus_Refresh_AccessToken.Domains.Entities;
using System.Threading.Tasks;

namespace ServiceDeskPlus_Refresh_AccessToken.UseCases
{
    public interface IRefreshAccessTokenUseCase
    {
        Task<RefreshAccessTokenResponse> ExecuteAsync();
    }
}
