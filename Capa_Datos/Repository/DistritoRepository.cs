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
    public class DistritoRepository : IGenericRepository<Distrito>
    {
        private readonly TrabajadoresDataContext _dbcontext;
        public DistritoRepository(TrabajadoresDataContext dbcontext)
        {
            _dbcontext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
        }

        public async Task<bool> Delete(int id)
        {
            Distrito? distrito = await _dbcontext.Distritos.FirstOrDefaultAsync(c => c.IdProvincia == id);
            if (distrito == null)
                return false;

            _dbcontext.Distritos.Remove(distrito);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Distrito>> GetAll()
        {
            IQueryable<Distrito> queryDistritoSql = _dbcontext.Distritos;
            return queryDistritoSql;
        }

        public async Task<Distrito> GetById(int id)
        {
            return await _dbcontext.Distritos.FindAsync(id);
        }

        public async Task<bool> Insert(Distrito model)
        {
            await _dbcontext.Distritos.AddAsync(model);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Distrito model)
        {
            var distritoExistente = await _dbcontext.Distritos.FindAsync(model.IdProvincia);
            if (distritoExistente == null)
                return false;

            _dbcontext.Entry(distritoExistente).CurrentValues.SetValues(model);

            await _dbcontext.SaveChangesAsync();
            return true;
        }


    }
}
