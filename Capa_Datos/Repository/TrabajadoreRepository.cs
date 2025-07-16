using Capa_Datos.DataContext;
using Capa_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Repository
{
    internal class TrabajadoreRepository : IGenericRepository<Trabajadore>
    {
        private readonly TrabajadoresDataContext _dbcontext;
        public TrabajadoreRepository(TrabajadoresDataContext dbcontext)
        {
            _dbcontext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
        }


        public async Task<bool> Delete(int id)
        {
            Trabajadore? trabajadore = await _dbcontext.Trabajadores.FirstOrDefaultAsync(c => c.Id == id);
            if (trabajadore == null)
                return false;

            _dbcontext.Trabajadores.Remove(trabajadore);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Trabajadore>> GetAll()
        {
            IQueryable<Trabajadore> queryTrabajadoresSql = _dbcontext.Trabajadores;
            return queryTrabajadoresSql;
        }

        public async Task<Trabajadore> GetById(int id)
        {
            return await _dbcontext.Trabajadores.FindAsync(id);
        }

        public async Task<bool> Insert(Trabajadore model)
        {
            await _dbcontext.Trabajadores.AddAsync(model);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Trabajadore model)
        {
            var trabajadorExistente = await _dbcontext.Trabajadores.FindAsync(model.Id);
            if (trabajadorExistente == null)
                return false;

            _dbcontext.Entry(trabajadorExistente).CurrentValues.SetValues(model);

            await _dbcontext.SaveChangesAsync();
            return true;
        }


    }
}
