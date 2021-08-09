using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using SynthFinManSystem.Model.Objects;
using SynthFinManSystem.Web.Abstract;
using SynthFinManSystem.Web.Configuration;

namespace SynthFinManSystem.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAccountBusiness _accountBusiness;

        public AccountController(IAccountBusiness accountBusiness)
        {
            _accountBusiness = accountBusiness;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        public virtual async System.Threading.Tasks.Task<ActionResult> VerificarInfoAccesoAsync([FromBody] JObject data)
        {
            string userName = data["userName"].ToObject<string>();
            string password = data["password"].ToObject<string>();
            try
            {
                User usuarioApp = _accountBusiness.validateUser(userName, password);
                if (usuarioApp.Valid)
                {
                    #region Configuracion de la Cookie de Autenticacion
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, usuarioApp.Name),
                        new Claim(ClaimTypes.NameIdentifier, usuarioApp.Username)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new Microsoft.AspNetCore.Authentication.AuthenticationProperties
                    {
                        //AllowRefresh = <bool>,
                        // Refreshing the authentication session should be allowed.

                        ExpiresUtc = DateTime.UtcNow.AddMinutes(90),
                        // The time at which the authentication ticket expires. A 
                        // value set here overrides the ExpireTimeSpan option of 
                        // CookieAuthenticationOptions set with AddCookie.

                        //IsPersistent = true,
                        // Whether the authentication session is persisted across 
                        // multiple requests. When used with cookies, controls
                        // whether the cookie's lifetime is absolute (matching the
                        // lifetime of the authentication ticket) or session-based.

                        //IssuedUtc = <DateTime>,
                        // The time at which the authentication ticket was issued.

                        //RedirectUri = <string>
                        // The full path or absolute URI to be used as an http 
                        // redirect response value.
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
                    #endregion
                    HttpContext.Session.SetObject("UsuarioApp", usuarioApp);
                }
                return Ok(usuarioApp);
            }
            catch (Exception exception)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }
    }
}
