using System.Runtime.Serialization;

namespace ServiceDeskPlus_Refresh_AccessToken.Domains.Entities
{
    [DataContract]
    public class RefreshAccessTokenResponse
    {
        /// <summary>
        /// アクセストークン
        /// </summary>
        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// APIドメイン
        /// </summary>
        [DataMember(Name = "api_domain")]
        public string ApiDomain { get; set; }

        /// <summary>
        /// トークンタイプ
        /// </summary>
        [DataMember(Name = "token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// アクセストークンの有効期限(秒)
        /// </summary>
        [DataMember(Name = "expires_in")]
        public int ExpiresIn { get; set; }
    }
}
