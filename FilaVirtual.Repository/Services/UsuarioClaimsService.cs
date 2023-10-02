using FilaVirtual.Util.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using static FilaVirtual.Business.Models.Enumerador.PPAEnumerador;

namespace FilaVirtual.Business.Services
{
    public class UsuarioClaimsService
    {
        private readonly ClaimsPrincipal User;
        public UsuarioClaimsService(ClaimsPrincipal claims)
        {
            User = claims;
        }

        public string GetClaimValue(string type)
        {
            var value = User.Claims.FirstOrDefault(x => x.Type == type).Value;

            return value;
        }
        public string Cpf => GetClaimValue("Cpf");
        public string Nome => GetClaimValue("Nome");

        public static ClaimsIdentity GenerateClaims(string userID,string cpf, string nome)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                     new GenericIdentity(userID),
                     new[]
                     {
                        new Claim("Cpf", cpf),
                        new Claim("Nome", nome),
                        new Claim(ClaimTypes.Role, EnumExtensions.GetDescricao(EPermissoes.Administrador).ToString())

                     });

            return new ClaimsIdentity(identity);
        }

        public static ClaimsIdentity AlterarClaims(List<Claim> claims, string cpf)
        {
            Claim removerItem;

            removerItem = claims.Where(c => c.Type.Equals(ClaimTypes.Role)).FirstOrDefault();
            claims.Remove(removerItem);

            removerItem = claims.Where(c => c.Type.Equals("Cpf")).FirstOrDefault();
            claims.Remove(removerItem);

            claims.Add(new Claim("Cpf", cpf));
            claims.Add(new Claim(ClaimTypes.Role, EnumExtensions.GetDescricao(EPermissoes.Administrador).ToString()));

            var userIdentity = new ClaimsIdentity(claims);

            return userIdentity;
        }

    }
}

