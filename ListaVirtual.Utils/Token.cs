using System.Security.Claims;
using System.Security.Principal;
//using static CONCURSOMS.ModelData.Logic.Enumerator.CADMIMSEnumerator;

namespace FIlaVirtual.Util
{
    public class Token
    {
        private readonly ClaimsPrincipal User;
        public Token(ClaimsPrincipal claims)
        {
            User = claims;
        }

        public string GetClaimValue(string type)
        {
            var value = User.Claims.FirstOrDefault(x => x.Type == type).Value;

            return value;
        }
        public string UsuarioID => GetClaimValue("AspNetUsersID");
        public string Nome => GetClaimValue("Nome");

        public string Email => GetClaimValue("Email");

        public string CPF => GetClaimValue("CPF");


        public IEnumerable<int> Perfis => GetClaimValue("Perfis").Split('|').Select(x => int.Parse(x));


        public static ClaimsIdentity GenerateClaims(string usuarioID, string nomeUsuario, string email, string cpf)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                     new GenericIdentity(nomeUsuario),

                     new[]
                    {
                new Claim("Nome", nomeUsuario),
                new Claim("CPF", cpf),
                new Claim("Email", email)
              
                //new Claim(ClaimTypes.Role, ((EPerfilGSI)perfilSelecionado).ToString())            
            });


            return new ClaimsIdentity(identity);
        }

        public static ClaimsIdentity AlterarClaims(List<Claim> claims, int perfilSelecionado)
        {
            Claim removerItem = claims.Where(c => c.Type.Equals("PerfilID")).FirstOrDefault();
            claims.Remove(removerItem);

            removerItem = claims.Where(c => c.Type.Equals(ClaimTypes.Role)).FirstOrDefault();
            claims.Remove(removerItem);

            claims.Add(new Claim("PerfilID", perfilSelecionado.ToString()));
            //claims.Add(new Claim(ClaimTypes.Role, EnumExtensions.GetDescricao(((EPerfilGSI)perfilSelecionado)).ToString()));

            var userIdentity = new ClaimsIdentity(claims);

            return userIdentity;
        }

    }
}
