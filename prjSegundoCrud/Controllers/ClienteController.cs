using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjSegundoCrud.DataContex;
using prjSegundoCrud.Models;

namespace prjSegundoCrud.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        #region "Constructor"

        private readonly AplicationDbContext _context;

        public ClienteController(AplicationDbContext context)
        {

            _context = context;

        }

        #endregion

        #region "ListarDatos"

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cliente.ToListAsync());
        }

        #endregion

        #region "Crear"

        [HttpGet]

        public IActionResult Create()
        {

            return View();

        }

        public async Task<IActionResult> Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Cliente.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        #endregion

        #region "Editar"

        //obteniemos los valores en el formulario editar

        [HttpGet]
        public IActionResult Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();

            }

            var cliente = _context.Cliente.Find(id);

            if (cliente == null)
            {
                return NotFound();

            }

            return View(cliente);
        }

        //funcion para editar
        [HttpPost]

        public async Task<IActionResult> Edit(Cliente cliente)

        {
            if (ModelState.IsValid)
            {

                _context.Update(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            return View(cliente);

        }

        #endregion

        #region "Eliminar"

        [HttpPost, ActionName("Delete")]// datos que enviamos al formulario

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRegistro(int id)

        {
            var cliente = await _context.Cliente.FindAsync(id);

            if (cliente == null)
            {
                return View();
            }

            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        #endregion

    }
}