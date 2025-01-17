using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.People;
using RabbitHelper;
using System.Diagnostics;

namespace Application.Infrastructure.Repositories
{
    public class InfraPersonRepository : IDataManagementRepository<Person>
    {
        //TO BE REPLACED WITH REAL LOGIC
        private DbContext _context;

        public InfraPersonRepository(DbContext context)
        {
            RabbitHelperService.Init().Wait();
            _context = context;
        }

        public async Task<List<Person>> GetAllAsync(Func<Person, bool> predicate, CancellationToken ct)
        {
            var result = await Task.Run( () => _context.Set<Person>().Where(predicate).ToList(), ct);
            return result;
        }

        public async Task<Person?> GetByIdAsync(uint id, CancellationToken ct)
        {
            var result = await _context.Set<Person>().FindAsync(new { id }, ct);
            return result;
        }

        public async Task<Person?> CreateAsync(Person? person, CancellationToken ct)
        {
            if (person is null) return null;

            var result = await _context.Set<Person>().AddAsync(person, ct);
            await _context.SaveChangesAsync(ct);
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(uint id, CancellationToken ct)
        {
            var person = await _context.Set<Person>().FindAsync(new { id }, ct);
            if (person != null)
            {
                try
                {
                    await Task.Run(() => _context.Set<Person>().Remove(person), ct);
                    await _context.SaveChangesAsync(ct);
                    return true;
                }
                catch (Exception)
                {
                    if (Debugger.IsAttached) throw;
                    return false;
                }
            }
            else return false;
        }

        public async Task<bool> UpdateAsync(uint id, Person? person, CancellationToken ct)
        {
            var existingPerson = await _context.Set<Person>().FindAsync(new { id }, ct);
            if (existingPerson != null)
            {
                try
                {
                    foreach (var property in typeof(Person).GetProperties())
                    {
                        var newValue = property.GetValue(person);
                        property.SetValue(existingPerson, newValue);
                    }
                    await _context.SaveChangesAsync(ct);
                    return true;
                }
                catch (Exception)
                {
                    if (Debugger.IsAttached) throw;
                    return false;
                }
            }
            else return false;
        }
    }
}
