using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjSegundoCrud.DataContex;
using prjSegundoCrud.Helper;
using prjSegundoCrud.Models;




namespace prjSegundoCrud.Controllers
{
   
    public class UsuarioController : Controller
    {
        #region "Constructor"

        private readonly AplicationDbContext _context;


        public UsuarioController(AplicationDbContext context)
        {

            _context = context;

        }

        #endregion

        #region "ListarDatos"

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var idusuario = DatosSesion.GetNameIdentifier(User);
            var usuario = await _context.Usuario.Where(u => u.Id != Int32.Parse(idusuario)).ToListAsync();

            return View(usuario);
        }

        #endregion

        #region "Crear"

        [HttpGet]

        public IActionResult Create()
        {

            return View();

        }

        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuario.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        #endregion

        #region "Editar"

        //obtenemos los valores en el formulario editar

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var usuario = _context.Usuario.Find(id);

            if (id == null || usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        //funcion para editar
        [HttpPost]

        public async Task<IActionResult> Edit(Usuario usuario)

        {
            if (ModelState.IsValid)
            {

                _context.Update(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            return View(usuario);

        }

        #endregion

        #region "Eliminar"

        [HttpPost, ActionName("Delete")]// datos que enviamos al formulario

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRegistro(int id)

        {
            var usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return View();
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        #endregion

        #region "ObtenerRol"

        [HttpGet]
        public IActionResult ObtenerRol()
        {

            var query = from r in _context.Rol

                        select new
                        {
                            id = r.Id,
                            nombre = r.RolName,
                        };

            return Json(query);

        }

        #endregion

        #region "Metodos Privados"

        [HttpGet]


        public IActionResult FiltraUsurioRol(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(false);
                }

                var query = from u in _context.Usuario
                            join r in _context.Rol on u.IdRol equals r.Id
                            where u.Id == id
                            select new
                            {
                                rolid = u.IdRol
                            };

                return Json(query);

            }
            catch (Exception)
            {

                return Json(false);
            }
        }

        #endregion

    }
}