using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppTask.DAL;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Product> ProductRepository { get; }

    Task<int> SaveChangesAsync();
}