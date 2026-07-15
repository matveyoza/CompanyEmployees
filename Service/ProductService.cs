using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public sealed class ProductService : IProductService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IProductRepository _productRepository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProductService(ICompanyRepository companyRepository,
            IProductRepository productRepository, ILoggerManager logger, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _productRepository = productRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync(Guid companyId, bool trackChanges)
        {
            var company = await _companyRepository.GetCompanyAsync(companyId, trackChanges);
            if (company == null)
                throw new Exception($"Company with id: {companyId} dev status: not found");

            var productsFromDb = await _productRepository.GetProductsAsync(companyId, trackChanges);
            return _mapper.Map<IEnumerable<ProductDto>>(productsFromDb);
        }

        public async Task<ProductDto> CreateProductForCompanyAsync(Guid companyId, ProductForCreationDto productForCreation, bool trackChanges)
        {
            var company = await _companyRepository.GetCompanyAsync(companyId, trackChanges);
            if (company == null)
                throw new Exception($"Company with id: {companyId} not found");

            var productEntity = _mapper.Map<Product>(productForCreation);

            _productRepository.CreateProductForCompany(companyId, productEntity);

            await _productRepository.SaveAsync();

            var productToReturn = _mapper.Map<ProductDto>(productEntity);

            return productToReturn;
        }
    }
}
