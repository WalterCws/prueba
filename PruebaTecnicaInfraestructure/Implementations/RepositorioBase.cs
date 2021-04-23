using Microsoft.EntityFrameworkCore;
using PruebaTecnicaCore.Entities;
using PruebaTecnicaCore.Interfaces;
using PruebaTecnicaInfraestructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaInfraestructure.Implementations
{
    public class RepositorioBase<T> : IRepositorio<T> where T : EntidadBase
    {
        private readonly VueloContext _dbContext;
        private readonly DbSet<T> _entidad;
        public RepositorioBase(VueloContext dbContext)
        {
            _dbContext = dbContext;
            _entidad = dbContext.Set<T>();
        }

        public async Task<List<T>> ObtenerTodosAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = _entidad.AsQueryable();

            if (includes.Count() > 0)
            {
                foreach (Expression<Func<T, object>> i in includes)
                {
                    query = query.Include(i);
                }
            }               
            return await query.ToListAsync();
        }

        public async Task<T> ObtenerPorIdAsync(int id)
        {
            return await _entidad.FindAsync(id);
        }

        public async Task<bool> AgregarAsync(T entidad)
        {
            _entidad.Add(entidad);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> ActualizarAsync(T entidad)
        {
            _entidad.Update(entidad);
            return await _dbContext.SaveChangesAsync() > 0;  
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var entidad = await ObtenerPorIdAsync(id);
            _entidad.Remove(entidad);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<List<T>> FindExpAsync(Expression<Func<T, bool>> expression)
        {
            return await _entidad.Where(expression).ToListAsync();
        }

        public async Task<List<T>> FindFilterAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = _entidad.Where(predicate);
            foreach (Expression<Func<T, object>> i in includes)
            {
                query = query.Include(i);
            }
            return await query.ToListAsync();
        }

        public Task<bool> AnyFilterAsync(Expression<Func<T, bool>> predicate)
        {
            return _entidad.AnyAsync(predicate);
        }

    }
}
