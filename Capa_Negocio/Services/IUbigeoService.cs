using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capa_Negocio.Services
{
    public interface IUbigeoService
    {
        List<SelectListItem> ObtenerTiposDocumento();
        List<SelectListItem> ObtenerDepartamentos();
        List<SelectListItem> ObtenerProvinciasPorDepartamento(int idDepartamento);
        List<SelectListItem> ObtenerDistritosPorProvincia(int idProvincia);
    }
}
