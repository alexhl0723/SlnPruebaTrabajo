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
    public class ProvinciumRepository : IGenericRepository<Provincium>
    {
        private readonly TrabajadoresDataContext _dbcontext;
        public ProvinciumRepository(TrabajadoresDataContext dbcontext)
        {
            _dbcontext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
        }

        public async Task<bool> Delete(int id)
        {
            Provincium? provincium = await _dbcontext.Provincia.FirstOrDefaultAsync(c => c.IdDepartamento == id);
            if (provincium == null)
                return false;

            _dbcontext.Provincia.Remove(provincium);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Provincium>> GetAll()
        {
            IQueryable<Provincium> queryProvinciaSql = _dbcontext.Provincia;
            return queryProvinciaSql;
        }

        public async Task<Provincium> GetById(int id)
        {
            return await _dbcontext.Provincia.FindAsync(id);
        }

        public async Task<bool> Insert(Provincium model)
        {
            await _dbcontext.Provincia.AddAsync(model);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Provincium model)
        {
            var provinciaExistente = await _dbcontext.Provincia.FindAsync(model.IdDepartamento);
            if (provinciaExistente == null)
                return false;

            _dbcontext.Entry(provinciaExistente).CurrentValues.SetValues(model);

            await _dbcontext.SaveChangesAsync();
            return true;
        }


    }
}
