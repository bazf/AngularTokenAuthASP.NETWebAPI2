using BLL.Interfaces.IServices;
using BLL.Services;
using DAL.Entities;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace WEB.Providers
{
    public class DevComTestAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly IAuthenticationService authService;

        public DevComTestAuthProvider(IAuthenticationService authService)
        {
            this.authService = authService;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Run(() => context.Validated());
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            var header = context.OwinContext.Response.Headers.SingleOrDefault(h => h.Key == "Access-Control-Allow-Origin");
            if (header.Equals(default(KeyValuePair<string, string[]>)))
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            }

            UserEntity user = await authService.FindUser(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }


            //var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            //identity.AddClaim(new Claim("sub", context.UserName));
            //identity.AddClaim(new Claim("role", "user"));


            //context.Validated(identity);

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            var roles = await authService.GetAllRoles(user.Id);

            if (roles.Count() > 0)
            {
                foreach (var role in roles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));
                }
            }


            var rolesString = await authService.GetAllRolesJson(user.Id);
            AuthenticationProperties properties = CreateProperties(user.UserName, rolesString, user.Id);
            AuthenticationTicket ticket = new AuthenticationTicket(identity, properties);

            context.Validated(ticket);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        private AuthenticationProperties CreateProperties(string userName, string roles, string id)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName },
                { "roles", roles },
                { "id", id }
            };
            return new AuthenticationProperties(data);
        }
    }
}