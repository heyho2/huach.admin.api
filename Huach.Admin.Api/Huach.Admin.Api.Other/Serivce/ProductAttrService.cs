using Huach.Admin.IRepository.Basic;
using Huach.Admin.Models.Basic;

namespace Huach.Admin.Service.Basic
{    
    /// <summary>
    /// ProductAttrService 
    /// </summary>
    public class ProductAttrService: ServiceBase<ProductAttr>  
    {    
		private readonly IProductAttrRepository _productAttrRepository;
		public ProductAttrService(IProductAttrRepository productAttrRepository)
			:base(productAttrRepository)
		{
			_productAttrRepository = productAttrRepository;
		}
    }
}
    
