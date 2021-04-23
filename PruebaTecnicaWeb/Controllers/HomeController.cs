using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaTecnicaWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager,
                              SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Registro()
        {
            return View();
        }

        public IActionResult Logueo()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> VerificarCorreo(string correo)
        {
            bool esValido = false;
            try
            {
                esValido = await _userManager.FindByEmailAsync(correo) == null;
            }
            catch (Exception error)
            {

            }
            return new JsonResult(esValido);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarUsuario(UsuarioModel model)
        {
            int statusCode = StatusCodes.Status200OK;

            bool salida = false;
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new IdentityUser
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        EmailConfirmed = true,
                    };

                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        return RedirectToAction("Logueo", "Home");
                    }
                }
            }
            catch(Exception e)
            {
                statusCode = StatusCodes.Status500InternalServerError;
            }

            return StatusCode(statusCode, salida);
        }

        public async Task<IActionResult> IniciarSesion(UsuarioModel model)
        {
            int statusCode = StatusCodes.Status200OK;
            bool inicioValido = false;
            try
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Vuelos", new { Areas = "Vuelos" });
                }                
            }
            catch(Exception e)
            {
                statusCode = StatusCodes.Status500InternalServerError;
            }
           
            return StatusCode(statusCode, inicioValido);
        }
    }
}
