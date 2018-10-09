using Huach.Admin.IRepository.Basic;
using Huach.Admin.Models.Basic;

namespace Huach.Admin.Service.Basic
{    
    /// <summary>
    /// SysDictionaryTypeService 
    /// </summary>
    public class SysDictionaryTypeService: BaseService<SysDictionaryType>  
    {    
		private readonly ISysDictionaryTypeRepository _sysDictionaryTypeRepository;
		public SysDictionaryTypeService(ISysDictionaryTypeRepository sysDictionaryTypeRepository)
			:base(sysDictionaryTypeRepository)
		{
			_sysDictionaryTypeRepository = sysDictionaryTypeRepository;
		}
    }
}
    
