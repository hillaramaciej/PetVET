using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using JwtAuthenticationHelper;
using JwtAuthenticationHelper.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PetVET.Models;

namespace TokenManager.Api.Services
{
    public class TokenManagerMiddleware : IMiddleware
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtTokenGenerator tokenGenerator;

        public TokenManagerMiddleware(IHttpContextAccessor httpContextAccessor, IJwtTokenGenerator tokenGenerator)
        {
            _httpContextAccessor = httpContextAccessor;
            this.tokenGenerator = tokenGenerator;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var authenticationCookieName = ".AspNetCore.Cookies";
            var authenticationCookieName1 = ".Token.jwt";
            var cookie = context.Request.Cookies[authenticationCookieName];
            var cookie1 = context.Request.Cookies[authenticationCookieName1];
            // var y = secureDataFormat;
            var services = context.RequestServices;//.GetRequiredService<IServiceScopeFactory>().CreateScope())


            if (cookie != null)
            {

                //services.GetService<IConfigurationSection>();
                //Microsoft.Extensions.Configuration.IConfigurationSection appSettingsSection = services.GetRequiredService<IConfigurationSection>().GetSection("AppSettings");
                //var key = Encoding.ASCII.GetBytes(services.GetRequiredService<AppSettings>().Secret);

                var key = Encoding.ASCII.GetBytes("OfED+KgbZ44xtu4e4+JSQWdtSgTnsuNixKy1nMVAf4Ewws8QL3IN33XusJhrz9HXmIrdyX2F41xJHG4fuj5/2Dzv3xjYYvqxexmg3X3X5TOf3WoMs1VNloJ7UnbqUJOiEjgK8sRdJntgfomO4U8s67cpysk0h9rc0He4xRspEjOapFfDg+VG8igidcNgbNDSSaV4491Fo3sq2aGSCtYvekzs7JwXJnNAyvDSJjfK/7M8MpxSMnm1vMscBXyiYFXhGC4wqWlYBE828/5DNyw3QZW5EjD7hvDrY5OlYd4smCTa53helNnJz5NT9HQaDbE2sMwIDAQABAoIBAEs63TvT94njrPDP3A/sfCEXg1F2y0D/PjzUhM1aJGcRiOUXnGlYdViGhLnnJoNZTZm9qI1LT0NWcDA5NmBN6gcrk2EApyTt1D1i4AQ66rYoTF9iEC4Wye28v245BYESA6IIelgIxXGsVyllERsbTkaphzib44bYfHmvwMxkn135Zfzd/NOXl/O32vYIomzrNEP+tN2444WXhhG8c8+iZ8PErBV3CqrYogYy97d2CeQbXcpd5unPiU4TK0nnzeBAXdgeYuJHFC45YHl9UvShRoe6CHR47ceIGp6WMc5BTyyTkZpctuYJTwaChdj/QuRSkTYmn6jFL+MRfYQJ8VVwSVo5DbkECgYEA4/YIMKcwObYcSuHzgkMwH645CRDoy9M98eptAoNLdJBHYz23U5IbGL1+qHDDCPXx123Ks9ZG7EEqyWezq4qwe2eoFoebLA5O6/xrYXoaeIb0!@#$94dbCF4D932hAkgAaAZkZVsSiWDCjYSV+444JoWX4NVBcIL9yyHRhaaPVULsdfTRbPsZQWq9+hMCgYEA48j4RGO7CaVpgUVobYasJnkGSdhkSCd1VwgvHH3vtuk7/JGUBRaZc0WZGcXkAJXnLh7QnDHOzWASdaxVgnuviaDi4CIkmTCfRqPesgDR2Iu35iQsH7P2/o1pzhpXQS/Ct6J7/GwJTqcXCvp4tfZDbFxS8oewzp4RstILj+pDyWECgYByQAbOy5xB8GGxrhjrOl1OI3V2c8EZFqA/NKy5y6/vlbgRpwbQnbNy7NYj+Y/mV80tFYqldEzQsiQrlei78Uu5YruGgZogL3ccj+izUPMgmP4f6+9XnSuN9rQ3jhy4k4zQP1BXRcim2YJSxhnGV+1hReLknTX2IwmrQxXfUW4xfQKBgAHZW8qSVK5bXWPjQFnDQhp92QM4cnfzegxe0KMWkp+VfRsrw1vXNx");
 


                var validationParams = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero,

                    ValidateAudience = true,
                    //ValidAudience = Configuration["Token:Audience"],
                    ValidAudience = "http://localhost:44330/",

                    ValidateIssuer = true,
                    // ValidIssuer = Configuration["Token:Issuer"],
                    ValidIssuer = "http://localhost:44330/",

                    // IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Token:SigningKey"])),
                    IssuerSigningKey = new SymmetricSecurityKey(key),

                    ValidateIssuerSigningKey = true,

                    RequireExpirationTime = true,
                    ValidateLifetime = true
                };



                var hostingEnvironment = services.GetRequiredService<IHostingEnvironment>();

                var ticket = new JwtAuthTicketFormat(validationParams,
                   services.GetRequiredService<IDataSerializer<AuthenticationTicket>>(),
                   services.GetDataProtector(new[]
                   {
                        $"{hostingEnvironment.ApplicationName}-Auth1"
                   }));
              AuthenticationTicket t = ticket.Unprotect(cookie);


                if (t != null)
                {
                    var dt = DateTime.Now;

                    var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                    var token = jwtSecurityTokenHandler.ReadJwtToken(t.Properties.Items[".Token.jwt"]);
                    var to = token.Claims.ToList();

                    var mail = to.Find(x => x.Type == ClaimTypes.Name).Value;
                    if ((token.ValidTo.AddHours(1) - dt).TotalSeconds   > 0  && (token.ValidTo.AddHours(1) - dt).TotalSeconds < 15 ){

                        var accessTokenResult = tokenGenerator.GenerateAccessTokenWithClaimsPrincipal(
                        mail,
                        token.Claims);

                        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                        JwtSecurityToken tt = handler.ReadToken(accessTokenResult.AccessToken) as JwtSecurityToken;

                        await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                        await context.SignInAsync(accessTokenResult.ClaimsPrincipal,
                            accessTokenResult.AuthProperties);
                    }



                    //var yyyyyy =  context.User?.FindFirst(ClaimTypes.GivenName).Value;




                }
            }


            if (true)
            {
                await next(context);

                return;
            }
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
    }
}