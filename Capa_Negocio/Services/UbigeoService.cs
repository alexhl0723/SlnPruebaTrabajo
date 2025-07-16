using Capa_Datos.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capa_Negocio.Services
{
    public class UbigeoService : IUbigeoService
    {
        private readonly TrabajadoresDataContext _context;

        public UbigeoService(TrabajadoresDataContext context)
        {
            _context = context;
        }

        public List<SelectListItem> ObtenerTiposDocumento()
        {
            return new List<SelectListItem>
        {
            new SelectListItem { Value = "DNI", Text = "DNI" },
            new SelectListItem { Value = "Carnet de Extranjería", Text = "Carnet de Extranjería" },
            new SelectListItem { Value = "Pasaporte", Text = "Pasaporte" }
        };
        }

        public List<SelectListItem> ObtenerDepartamentos()
        {
            return _context.Departamentos
                .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.NombreDepartamento })
                .ToList();
        }

        public List<SelectListItem> ObtenerProvinciasPorDepartamento(int idDepartamento)
        {
            return _context.Provincia
                .Where(p => p.IdDepartamento == idDepartamento)
                .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.NombreProvincia })
                .ToList();
        }

        public List<SelectListItem> ObtenerDistritosPorProvincia(int idProvincia)
        {
            return _context.Distritos
                .Where(d => d.IdProvincia == idProvincia)
                .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.NombreDistrito })
                .ToList();
        }

    }
}
