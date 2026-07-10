using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync(Guid companyId,bool trackChanges);
        void CreateProductForCompany(Guid companyId, Product product);
    }
}
