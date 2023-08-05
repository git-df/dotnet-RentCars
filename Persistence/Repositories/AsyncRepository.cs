#pragma warning disable 8603
using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly RentCarsDbContext _context;

        public AsyncRepository(RentCarsDbContext rentCarsDbContext)
        {
            _context = rentCarsDbContext;
        }

        public async Task<T> Add(T entity)
        {
            await _context.Set<T>()
                .AddAsync(entity);
            
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>()
                .Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>()
                .FindAsync(id);
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity)
                .State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
