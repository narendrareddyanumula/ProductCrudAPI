// Application/Interfaces/IProductService.cs
using Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(int id);
        Task AddAsync(ProductDto product);
        Task UpdateAsync(ProductDto product);
        Task DeleteAsync(int id);
    }
}
