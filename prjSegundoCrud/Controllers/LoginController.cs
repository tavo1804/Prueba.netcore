using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using prjSegundoCrud.DataContex;

namespace prjSegundoCrud.Controllers
{
    public class LoginController : Controller

    {

        #region "Constructor"

        private readonly AplicationDbContext _context;

        public LoginController(AplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region "Index"

        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region "Metodos Privados"

        public async Task<IActionResult> GetUsuariosAsync(string nombreusuario, string password)
        {
            var usuario = _context.Usuario.Where(u => u.User == nombreusuario && u.Password == password);
            var result = _context.Usuario.Where(u => u.User == nombreusuario).SingleOrDefault();


            if (usuario.Any())
            {
                if (usuario.Where(u => u.User == nombreusuario && u.Password == password).Any())
                {
                    //codigo para iniciar sesion
                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name,
                        ClaimTypes.Role);
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, result.Id.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.Name, result.Nombre));
                    identity.AddClaim(new Claim(ClaimTypes.Email, "gustavov1807@hotmail.com"));
                    identity.AddClaim(new Claim("Dato", "valor"));
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                    new AuthenticationProperties { ExpiresUtc = DateTime.Now.AddDays(1), IsPersistent = true });
                    //codigo para iniciar sesion


                    return Json(new { status = true, message = "Bienvenido" });
                }
                else
                {
                    return Json(new { status = false, message = "Clave Incorrecta" });

                }
            }
            else
            {
                return Json(new { status = false, message = "Usuario Incorrecto" });

            }

        }

        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Login");

        }

        #endregion


    }
}