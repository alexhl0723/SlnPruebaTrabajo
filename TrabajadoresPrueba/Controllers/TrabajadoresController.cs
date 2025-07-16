using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Capa_Datos.DataContext;
using Capa_Models;
using Capa_Negocio.Services;
using Capa_Models.ViewModels;

namespace TrabajadoresPrueba.Controllers
{
    public class TrabajadoresController : Controller
    {
        private readonly TrabajadoresDataContext _context;
        

        public TrabajadoresController(TrabajadoresDataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string sexo)
        {
            List<TrabajadorVM> trabajadores;

            if (string.IsNullOrEmpty(sexo))
            {
                trabajadores = await _context.Set<TrabajadorVM>()
                    .FromSqlRaw("EXEC sp_ListarTrabajadores")
                    .ToListAsync();
            }
            else
            {
                trabajadores = await _context.Set<TrabajadorVM>()
                    .FromSqlRaw("EXEC sp_ListarTrabajadoresSexo @sexo = {0}", sexo)
                    .ToListAsync();
            }

            ViewBag.SexoSeleccionado = sexo;
            return View(trabajadores);
        }
        //esto es porque en el db hay repetidos
        private List<Departamento> ObtenerDepartamentosUnicos()
        {
            return _context.Departamentos
                .GroupBy(d => d.NombreDepartamento)
                .Select(g => g.First())
                .ToList();
        }



        private void CargarDocumentos()
        {
            ViewBag.TiposDocumento = new List<SelectListItem>
            {
            new SelectListItem { Value = "DNI", Text = "DNI" },
            new SelectListItem { Value = "CE", Text = "Carnet de Extranjería" },
            new SelectListItem { Value = "PAS", Text = "Pasaporte" }
            };
        }

        [HttpGet]
        public JsonResult GetProvincias(int idDepartamento)
        {
            var provincias = _context.Provincia
                .Where(p => p.IdDepartamento == idDepartamento)
                .Select(p => new { p.Id, p.NombreProvincia })
                .ToList();

            return Json(provincias);
        }

        [HttpGet]
        public JsonResult GetDistritos(int idProvincia)
        {
            var distritos = _context.Distritos
                .Where(d => d.IdProvincia == idProvincia)
                .Select(d => new { d.Id, d.NombreDistrito })
                .ToList();

            return Json(distritos);
        }

        public IActionResult Create()
        {
            CargarDocumentos();

            ViewData["IdDepartamento"] = new SelectList(ObtenerDepartamentosUnicos(), "Id", "NombreDepartamento");
            ViewData["IdProvincia"] = new SelectList(_context.Provincia, "Id", "NombreProvincia");
            ViewData["IdDistrito"] = new SelectList(_context.Distritos, "Id", "NombreDistrito");

            return PartialView("_Crear");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoDocumento,NumeroDocumento,Nombres,Sexo,IdDepartamento,IdProvincia,IdDistrito")] Trabajadore trabajadore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trabajadore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            CargarDocumentos();

            ViewData["IdDepartamento"] = new SelectList(ObtenerDepartamentosUnicos(), "Id", "NombreDepartamento", trabajadore.IdDepartamento);
            ViewData["IdProvincia"] = new SelectList(_context.Provincia, "Id", "NombreProvincia", trabajadore.IdProvincia);
            ViewData["IdDistrito"] = new SelectList(_context.Distritos, "Id", "NombreDistrito", trabajadore.IdDistrito);

            return View(trabajadore);
        }



        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabajadore = await _context.Trabajadores.FindAsync(id);
            if (trabajadore == null)
            {
                return NotFound();
            }

            CargarDocumentos();

            ViewData["IdDepartamento"] = new SelectList(ObtenerDepartamentosUnicos(), "Id", "NombreDepartamento", trabajadore.IdDepartamento);
            ViewData["IdProvincia"] = new SelectList(_context.Provincia, "Id", "NombreProvincia", trabajadore.IdProvincia);
            ViewData["IdDistrito"] = new SelectList(_context.Distritos, "Id", "NombreDistrito", trabajadore.IdDistrito);

            return PartialView("_Editar",trabajadore);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoDocumento,NumeroDocumento,Nombres,Sexo,IdDepartamento,IdProvincia,IdDistrito")] Trabajadore trabajadore)
        {
            if (id != trabajadore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trabajadore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrabajadoreExists(trabajadore.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDepartamento"] = new SelectList(ObtenerDepartamentosUnicos(), "Id", "NombreDepartamento", trabajadore.IdDepartamento);
            ViewData["IdProvincia"] = new SelectList(_context.Provincia, "Id", "NombreProvincia", trabajadore.IdProvincia);
            ViewData["IdDistrito"] = new SelectList(_context.Distritos, "Id", "NombreDistrito", trabajadore.IdDistrito);

            return View(trabajadore);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabajadore = await _context.Trabajadores
                .Include(t => t.IdDepartamentoNavigation)
                .Include(t => t.IdDistritoNavigation)
                .Include(t => t.IdProvinciaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trabajadore == null)
            {
                return NotFound();
            }

            return View(trabajadore);
        }

        // POST: Trabajadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trabajadore = await _context.Trabajadores.FindAsync(id);
            if (trabajadore != null)
            {
                _context.Trabajadores.Remove(trabajadore);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrabajadoreExists(int id)
        {
            return _context.Trabajadores.Any(e => e.Id == id);
        }
    }
}
