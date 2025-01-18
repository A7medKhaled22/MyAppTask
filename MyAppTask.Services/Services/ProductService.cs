using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAppTask.DAL;

namespace MyAppTask.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ProductDto>> GetAllProducts()
    {
        var products = await _unitOfWork.ProductRepository.GetAll();
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<ProductDto> GetProductById(int id)
    {
        var product = await _unitOfWork.ProductRepository.GetById(id);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<int> CreateProduct(ProductAddDto productAddDto)
    {
       var product = _mapper.Map<Product>(productAddDto);
       await _unitOfWork.ProductRepository.Create(product);
       return product.Id;
    }

    public async Task UpdateProduct(int id, ProductDto productDto)
    {
        var existingProduct = await _unitOfWork.ProductRepository.GetById(id);
        if (existingProduct == null)
        {
            throw new KeyNotFoundException($"Product with ID {id} not found.");
        }
        _mapper.Map(productDto, existingProduct);
        await _unitOfWork.ProductRepository.Update(existingProduct);
    }

    public async Task DeleteProduct(int id)
    {
        var existingProduct = await _unitOfWork.ProductRepository.GetById(id);
        if (existingProduct == null)
        {
            throw new KeyNotFoundException($"Product with ID {id} not found.");
        }
        await _unitOfWork.ProductRepository.Delete(existingProduct);
    }
    
    public async Task CommitChanges()
    {
        await _unitOfWork.SaveChangesAsync();
    }
}