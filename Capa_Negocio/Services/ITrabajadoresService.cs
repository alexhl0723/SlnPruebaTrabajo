using Capa_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Services
{
    public interface ITrabajadoresService
    {
        Task<bool> Insert(Trabajadore model);
        Task<bool> Update(Trabajadore model);
        Task<bool> Delete(int id);
        Task<Trabajadore> GetById(int id);
        Task<IQueryable<Trabajadore>> GetAll();

        //poner metodos adicionales si es necesario
        //por ejemplo 
        //a. Agregar Filtro Por Sexo
        //b.Pintar Fila del listado Azul Masculino | Naranja Femenino

        Task<IQueryable<Trabajadore>> trabajadoresPorSexo(string sexo);


    }
}
