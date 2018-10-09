using Huach.Admin.IRepository.Basic;
using Huach.Admin.Models.Basic;

namespace Huach.Admin.Service.Basic
{    
    /// <summary>
    /// ProductTypeService 
    /// </summary>
    public class ProductTypeService: BaseService<ProductType>  
    {    
		private readonly IProductTypeRepository _productTypeRepository;
		public ProductTypeService(IProductTypeRepository productTypeRepository)
			:base(productTypeRepository)
		{
			_productTypeRepository = productTypeRepository;
		}
    }
}
    
