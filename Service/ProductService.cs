using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class ProductService : IProductService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync(Guid companyId, bool trackChanges)
        {
            var company = await _repository.Company.GetCompanyAsync(companyId, trackChanges);
            if (company == null)
                throw new Exception($"Company with id: {companyId} dev status: not found");

            var productsFromDb = await _repository.Product.GetProductsAsync(companyId, trackChanges);
            return _mapper.Map<IEnumerable<ProductDto>>(productsFromDb);
        }

        public async Task<ProductDto> CreateProductForCompanyAsync(Guid companyId, ProductForCreationDto productForCreation, bool trackChanges)
        {
            var company = await _repository.Company.GetCompanyAsync(companyId, trackChanges);
            if (company == null)
                throw new Exception($"Company with id: {companyId} not found");

            var productEntity = _mapper.Map<Product>(productForCreation);

            _repository.Product.CreateProductForCompany(companyId, productEntity);

            await _repository.SaveAsync();

            var productToReturn = _mapper.Map<ProductDto>(productEntity);

            return productToReturn;
        }
    }
}
