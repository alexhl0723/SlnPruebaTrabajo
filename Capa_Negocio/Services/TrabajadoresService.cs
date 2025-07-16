using Capa_Datos.DataContext;
using Capa_Datos.Repository;
using Capa_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Services
{
    public class TrabajadoresService : ITrabajadoresService
    {
        private readonly IGenericRepository<Trabajadore> _genericRepository;
        private readonly TrabajadoresDataContext _context;
        


        public TrabajadoresService(IGenericRepository<Trabajadore> genericRepository, TrabajadoresDataContext context)
        {
            _genericRepository = genericRepository;
            _context = context;
        }

        public async Task<bool> Delete(int id)
        {
            return await _genericRepository.Delete(id);
        }

        public Task<IQueryable<Trabajadore>> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public Task<Trabajadore> GetById(int id)
        {
            return _genericRepository.GetById(id);
        }

        public Task<bool> Insert(Trabajadore model)
        {
            return _genericRepository.Insert(model);
        }

        public Task<bool> Update(Trabajadore model)
        {
            return _genericRepository.Update(model);
        }

        //extras
        public async Task<IQueryable<Trabajadore>> trabajadoresPorSexo(string sexo)
        {
            IQueryable<Trabajadore> query = await _genericRepository.GetAll();
            return query.Where(t => t.Sexo == sexo);
        }

        



    }
}
