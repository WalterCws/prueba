using PruebaTecnicaCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaCore.Interfaces
{
    public interface IRepositorio<T> where T : EntidadBase
    {
        Task<List<T>> ObtenerTodosAsync(params Expression<Func<T, object>>[] includes);

        Task<T> ObtenerPorIdAsync(int id);

        Task<bool> AgregarAsync(T entity);

        Task<bool> ActualizarAsync(T entity);

        Task<bool> EliminarAsync(int id);

        Task<List<T>> FindFilterAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        Task<bool> AnyFilterAsync(Expression<Func<T, bool>> predicate);

    }
}
