using Huach.Admin.IRepository.Basic;
using Huach.Admin.Models.Basic;

namespace Huach.Admin.Service.Basic
{    
    /// <summary>
    /// SysDictionaryService 
    /// </summary>
    public class SysDictionaryService: BaseService<SysDictionary>  
    {    
		private readonly ISysDictionaryRepository _sysDictionaryRepository;
		public SysDictionaryService(ISysDictionaryRepository sysDictionaryRepository)
			:base(sysDictionaryRepository)
		{
			_sysDictionaryRepository = sysDictionaryRepository;
		}
    }
}
    
