using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using PPA.Business.Models;
using System.Security.Claims;

using System.Security.Principal;
using FilaVirtual.Business.Interfaces.Service;
using FilaVirtual.Util.Configuration;
using FIlaVirtual.Util.Configuration;
using FilaVirtual.Business.Models;
using FilaVirtual.Business.Services;
using FilaVirtual.Util.Extensions;
using static FilaVirtual.Business.Models.Enumerador.PPAEnumerador;
using System.IdentityModel.Tokens.Jwt;

namespace PPA.Business.Services
{
    public class LoginServices : ILoginServices
    {
        public object GenerateToken(AspNetUsers user, SigningConfiguration signingConfigurations, TokenConfiguration tokenConfigurations)
        {
            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = tokenConfigurations.IsExpiration ? dataCriacao +
                TimeSpan.FromMinutes(tokenConfigurations.AccessExpiration) : DateTime.MaxValue;

            var identity = UsuarioClaimsService.GenerateClaims(user.AspNetUsersID.ToString(), user.CPF.ToString(), user.Nome.ToString());

            var handler = new JwtSecurityTokenHandler();

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });

            var token = handler.WriteToken(securityToken);

            return new
            {
                authenticated = true,
                created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                expirationSeconds = tokenConfigurations.AccessExpiration * 60,
                expiration = dataExpiracao,
                access_token = token,
                message = "Usuário autenticado com sucesso.",
            };
        }


        public object GenerateTokenRelatorios( SigningConfiguration signingConfigurations, TokenConfiguration tokenConfigurations)
        {
            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = tokenConfigurations.IsExpiration ? dataCriacao +
                TimeSpan.FromMinutes(tokenConfigurations.AccessExpiration) : DateTime.MaxValue;

            var identity =  new ClaimsIdentity(                     
                     new[]
                     {                        
                        new Claim(ClaimTypes.Role, EnumExtensions.GetDescricao(EPermissoes.AdministradorRelatorios).ToString())

                     });

            var handler = new JwtSecurityTokenHandler();

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });

            var token = handler.WriteToken(securityToken);

            return new
            {
                authenticated = true,
                created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                expirationSeconds = tokenConfigurations.AccessExpiration * 60,
                expiration = dataExpiracao,
                access_token = token,
                message = "Usuário autenticado com sucesso.",
            };
        }

        public object EditToken(SigningConfiguration signingConfigurations, TokenConfiguration tokenConfigurations, List<Claim> claims, string cpf)
        {

            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = tokenConfigurations.IsExpiration ? dataCriacao +
                TimeSpan.FromMinutes(tokenConfigurations.AccessExpiration) : DateTime.MaxValue;

            var claimsNova = UsuarioClaimsService.AlterarClaims(claims, cpf);
            var handler = new JwtSecurityTokenHandler();

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = claimsNova,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });

            var token = handler.WriteToken(securityToken);

            return new
            {
                authenticated = true,
                created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = dataExpiracao,
                access_token = token,
                message = "Usuário autenticado com sucesso.",
            };
        }

        public object RefreshToken(SigningConfiguration signingConfigurations, TokenConfiguration tokenConfigurations, List<Claim> claims)
        {

            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = tokenConfigurations.IsExpiration ? dataCriacao +
                TimeSpan.FromMinutes(tokenConfigurations.AccessExpiration) : DateTime.MaxValue;

            Claim Cpf;

            Cpf = claims.Where(c => c.Type.Equals("Cpf")).FirstOrDefault();
            var claimsNova = UsuarioClaimsService.AlterarClaims(claims, (Cpf.Value).ToString());

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = claimsNova,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });

            var token = handler.WriteToken(securityToken);

            return new
            {
                authenticated = true,
                created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                expirationSeconds = tokenConfigurations.AccessExpiration * 60,
                expiration = dataExpiracao,
                access_token = token,
                message = "Usuário autenticado com sucesso.",
            };

        }
    }
}
