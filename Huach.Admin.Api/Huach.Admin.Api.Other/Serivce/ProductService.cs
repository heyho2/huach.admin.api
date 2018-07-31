using Huach.Admin.IRepository.Basic;
using Huach.Admin.Models.Basic;

namespace Huach.Admin.Service.Basic
{    
    /// <summary>
    /// ProductService 
    /// </summary>
    public class ProductService: ServiceBase<Product>  
    {    
		private readonly IProductRepository _productRepository;
		public ProductService(IProductRepository productRepository)
			:base(productRepository)
		{
			_productRepository = productRepository;
		}
    }
}
    
