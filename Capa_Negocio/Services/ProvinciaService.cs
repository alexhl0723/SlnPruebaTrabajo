using Capa_Datos.Repository;
using Capa_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Services
{
    public class ProvinciaService : IProvinciaService
    {
        private readonly IGenericRepository<Provincium> _genericRepository;

        public ProvinciaService(IGenericRepository<Provincium> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<bool> Delete(int id)
        {
            return await _genericRepository.Delete(id);
        }

        public async Task<IQueryable<Provincium>> GetAll()
        {
            return await _genericRepository.GetAll();
        }

        public async Task<Provincium> GetById(int id)
        {
            return await _genericRepository.GetById(id);
        }

        public async Task<bool> Insert(Provincium model)
        {
            return await _genericRepository.Insert(model);  
        }

        public async Task<bool> Update(Provincium model)
        {
            return await _genericRepository.Update(model);
        }
    }
}
