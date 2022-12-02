using Colpatria.Application.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Colpatria.Security
{
    public class BasicAuthHandler: AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUserApp _userApp;
        public BasicAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder url, ISystemClock sis, IUserApp userApp): base(options, logger, url, sis)
        {
            _userApp = userApp;
        }
        //Clase asincrona que valida la autenticación correcta para el consumo de la api
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("No viene en la cabecera");

            bool result = false;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credtialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credtialBytes).Split(new[] { ':' }, 2);
                var email = credentials[0];
                var pass = credentials[1];
                result = _userApp.IsUser(email, pass);
            }
            catch (Exception ex)
            {

                return AuthenticateResult.Fail("Ocurrió un error inesperado: " + ex.Message);
            }
            if (!result)
                return AuthenticateResult.Fail("Usuario o contraseña inválida");

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "id"),
                new Claim(ClaimTypes.Name, "user")
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }

    }
}
