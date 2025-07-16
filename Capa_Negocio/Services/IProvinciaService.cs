using Capa_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Services
{
    public interface IProvinciaService
    {
        Task<bool> Insert(Provincium model);
        Task<bool> Update(Provincium model);
        Task<bool> Delete(int id);
        Task<Provincium> GetById(int id);
        Task<IQueryable<Provincium>> GetAll();
    }
}
