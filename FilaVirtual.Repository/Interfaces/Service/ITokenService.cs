using System.Security.Claims;
using FilaVirtual.Util.Configuration;
using FIlaVirtual.Util.Configuration;

namespace MSSUPERA.Business.Service
{
    public interface ITokenService
    {        
        public object GeneratePublicUserToken(SigningConfiguration signingConfigurations, TokenConfiguration tokenConfigurations, string userID, string nomeUsuario, Claim[] claims);
        public object EditToken(SigningConfiguration signingConfigurations, TokenConfiguration tokenConfigurations, List<Claim> claims, int grupoID);
    }
}
