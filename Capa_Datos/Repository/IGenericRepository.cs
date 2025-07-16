using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Repository
{
    public interface IGenericRepository<TEntityModel> where TEntityModel : class
    {
        Task<bool> Insert(TEntityModel model);
        Task<bool> Update(TEntityModel model);
        Task<bool> Delete(int id);
        Task<TEntityModel> GetById(int id);
        Task<IQueryable<TEntityModel>> GetAll();//trabajamos con IQueryable porque es para hacerlo directo de la db no de la memoria
    }
}
