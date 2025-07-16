using Capa_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Services
{
    public interface IDepartamentoService
    {
        Task<bool> Insert(Departamento model);
        Task<bool> Update(Departamento model);
        Task<bool> Delete(int id);
        Task<Departamento> GetById(int id);
        Task<IQueryable<Departamento>> GetAll();
    }
}
