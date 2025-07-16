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
    public class DepartamentoRepository : IGenericRepository<Departamento>
    {
        private readonly TrabajadoresDataContext _dbcontext;
        public DepartamentoRepository(TrabajadoresDataContext dbcontext)
        {
            _dbcontext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
        }

        public async Task<bool> Delete(int id)
        {
            Departamento? departamento = await _dbcontext.Departamentos.FirstOrDefaultAsync(c => c.Id == id);
            if (departamento == null)
                return false;

            _dbcontext.Departamentos.Remove(departamento);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Departamento>> GetAll()
        {
            IQueryable<Departamento> queryDepartamentoSql = _dbcontext.Departamentos;
            return queryDepartamentoSql;
        }

        public async Task<Departamento> GetById(int id)
        {
            return await _dbcontext.Departamentos.FindAsync(id);
        }

        public async Task<bool> Insert(Departamento model)
        {
            await _dbcontext.Departamentos.AddAsync(model);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Departamento model)
        {
            var departamentoExistente = await _dbcontext.Departamentos.FindAsync(model.Id);
            if (departamentoExistente == null)
                return false;

            _dbcontext.Entry(departamentoExistente).CurrentValues.SetValues(model);

            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
