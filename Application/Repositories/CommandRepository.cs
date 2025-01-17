using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Application.Repositories
{
    public class CommandRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;

        public CommandRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync(Func<T, bool> predicate, CToken ct)
        {
            var result = await Task.Run( () => _context.Set<T>().Where(predicate).ToList(), ct);
            return result;
        }
        public async Task<T?> GetByIdAsync(uint id, CToken ct)
        {
            var result = await Task.Run(() => _context.Set<T>().Find(id), ct);
            return result;
        }

        public async Task<T> CreateAsync(T item, CToken ct)
        {
            var result = await Task.Run(() => _context.Set<T>().Add(item), ct);
            var success = await _context.SaveChangesAsync(ct);

            if(success == 0) return null!;
            else return result.Entity;
        }
        
        public async Task<bool> UpdateAsync(T item, CToken ct)
        {
            try
            {
                await Task.Run(() => _context.Set<T>().Update(item), ct);
                var result = await _context.SaveChangesAsync(ct);
                return result > 0;
            }
            catch (Exception)
            {
                if (Debugger.IsAttached) throw;
                return false;
            }
        }

        public async Task<bool> UpdateAsync(List<T> list, CToken ct)
        {
            await _context.Database.BeginTransactionAsync(ct);
            try
            {
                await Task.Run(() => _context.Set<T>().UpdateRange(list), ct);
                var result = await _context.SaveChangesAsync(ct);
                await _context.Database.CommitTransactionAsync(ct);
                return result > 0;
            }
            catch
            {
                if (Debugger.IsAttached) throw;
                await _context.Database.RollbackTransactionAsync(ct);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(uint id, CToken ct)
        {
            try
            {
                var item = await GetByIdAsync(id, ct);
                if (item is null) return false;
                await Task.Run(() => _context.Set<T>().Remove(item), ct);
                var result = await _context.SaveChangesAsync(ct);
                return result > 0;
            }
            catch (Exception)
            {
                if (Debugger.IsAttached) throw;
                return false;
            }
        }
    }
}
