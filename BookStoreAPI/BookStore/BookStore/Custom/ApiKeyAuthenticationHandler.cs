using BookStore.Data.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace BookStore.Custom
{
    public class ApiKeyAuthenticationHandler : AuthenticationHandler<ApiKeyAuthenticationOptions>
    {
        private readonly IApplicationsRepository _applicationsRepository;

        public ApiKeyAuthenticationHandler(
          IOptionsMonitor<ApiKeyAuthenticationOptions> options,
          ILoggerFactory logger,
          UrlEncoder encoder,
          ISystemClock clock,
          IApplicationsRepository applicationsRepository) : base(options, logger, encoder, clock)
        {
            _applicationsRepository = applicationsRepository;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.NoResult();
            }

            if (!AuthenticationHeaderValue.TryParse(Request.Headers["Authorization"], out AuthenticationHeaderValue headerValue))
            {
                return AuthenticateResult.NoResult();
            }

            if (headerValue.Scheme != Options.Scheme)
            {
                return AuthenticateResult.NoResult();
            }

            var apiKey = headerValue.Parameter;

            var application = _applicationsRepository.GetByApiKey(apiKey);

            if(application != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim("Name", application.Name)
                };
                var identity = new ClaimsIdentity(claims, Options.AuthenticationType);
                var identities = new List<ClaimsIdentity> { identity };
                var principal = new ClaimsPrincipal(identities);
                var ticket = new AuthenticationTicket(principal, Options.Scheme);

                return AuthenticateResult.Success(ticket);
            }

            return AuthenticateResult.Fail("Invalid api key");
        }
    }
}
