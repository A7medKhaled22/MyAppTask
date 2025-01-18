using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppTask.DAL;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ProductContext _context;

    public GenericRepository(ProductContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetById(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task Create(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public async Task Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }

    public async Task Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
}