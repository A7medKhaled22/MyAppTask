using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppTask.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProducts();

    Task<ProductDto> GetProductById(int id);

    Task<int> CreateProduct(ProductAddDto productAddDto);

    Task UpdateProduct(int id, ProductDto productDto);

    Task DeleteProduct(int id);
    Task CommitChanges();
}