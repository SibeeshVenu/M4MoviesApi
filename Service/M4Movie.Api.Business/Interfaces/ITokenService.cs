using System;
using System.Collections.Generic;
using System.Text;

namespace M4Movie.Api.Business.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(string userName, string signInKey,
            string tokenIssuer, string tokenAudience);
    }
}
