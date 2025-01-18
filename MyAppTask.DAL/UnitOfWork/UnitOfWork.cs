using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppTask.DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProductContext _context;

    public UnitOfWork(ProductContext context)
    {
        _context = context;
        ProductRepository = new GenericRepository<Product>(_context);
    }

    public IGenericRepository<Product> ProductRepository { get; }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}