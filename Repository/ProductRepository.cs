using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }

        public async Task<IEnumerable<Product>> GetProductsAsync(Guid companyId, bool trackChanges) =>
            await FindByCondition(p => p.CompanyId.Equals(companyId), trackChanges)
            .OrderBy(p => p.Name)
            .ToListAsync();

        public void CreateProductForCompany(Guid companyId, Product product)
        {
            product.CompanyId = companyId;
            Create(product);
        }
    }
}
