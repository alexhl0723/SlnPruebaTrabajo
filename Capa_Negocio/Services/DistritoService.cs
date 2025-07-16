using Capa_Datos.Repository;
using Capa_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Services
{
    public class DistritoService : IDistritoService
    {
        private readonly IGenericRepository<Distrito> _distritoRepository;

        public DistritoService(IGenericRepository<Distrito> distritoRepository)
        {
            _distritoRepository = distritoRepository;
        }

        public async Task<bool> Delete(int id)
        {
            return await _distritoRepository.Delete(id);
        }

        public async Task<IQueryable<Distrito>> GetAll()
        {
            return await _distritoRepository.GetAll();
        }

        public async Task<Distrito> GetById(int id)
        {
            return await _distritoRepository.GetById(id);
        }

        public async Task<bool> Insert(Distrito model)
        {
            return await _distritoRepository.Insert(model);
        }

        public async Task<bool> Update(Distrito model)
        {
            return await _distritoRepository.Update(model);
        }

        //extras


    }
}
