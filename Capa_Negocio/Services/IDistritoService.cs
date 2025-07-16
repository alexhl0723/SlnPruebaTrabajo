using Capa_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Services
{
    public interface IDistritoService
    {

        Task<bool> Insert(Distrito model);
        Task<bool> Update(Distrito model);
        Task<bool> Delete(int id);
        Task<Distrito> GetById(int id);
        Task<IQueryable<Distrito>> GetAll();

        //poner metodos adicionales si es necesario
        //por ejemplo 
        //a. Agregar Filtro Por Sexo
        //b.Pintar Fila del listado Azul Masculino | Naranja Femenino


    }
}
