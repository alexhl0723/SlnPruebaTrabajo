using Capa_Datos.Repository;
using Capa_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IGenericRepository<Departamento> _genericRepository;

        public DepartamentoService(IGenericRepository<Departamento> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<bool> Delete(int id)
        {
            return await _genericRepository.Delete(id);
        }

        public async Task<IQueryable<Departamento>> GetAll()
        {
            return await _genericRepository.GetAll();
        }

        public async Task<Departamento> GetById(int id)
        {
            return await _genericRepository.GetById(id);
        }

        public async Task<bool> Insert(Departamento model)
        {
            return await _genericRepository.Insert(model);
        }

        public async Task<bool> Update(Departamento model)
        {
            return await _genericRepository.Update(model);
        }
    }
}
