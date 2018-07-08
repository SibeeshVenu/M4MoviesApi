namespace A4Auth.Api.Business.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(string userName, string signInKey,
            string tokenIssuer, string tokenAudience);
    }
}
