using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync(Guid companyId, bool trackChanges);
        Task<ProductDto> CreateProductForCompanyAsync(Guid companyId, ProductForCreationDto productForCreation, bool trackChanges);
    }
}
