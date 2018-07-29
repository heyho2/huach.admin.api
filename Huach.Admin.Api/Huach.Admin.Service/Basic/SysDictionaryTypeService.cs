using Huach.Admin.IRepository.Basic;
using Huach.Admin.Models.Basic;

namespace Huach.Admin.Service.Basic
{
    public class SysDictionaryTypeService : ServiceBase<SysDictionaryType>
    {
        private readonly ISysDictionaryTypeRepository _sysDictionaryTypeRepository;
        public SysDictionaryTypeService(ISysDictionaryTypeRepository sysDictionaryTypeRepository)
            : base(sysDictionaryTypeRepository)
        {
            _sysDictionaryTypeRepository = sysDictionaryTypeRepository;
        }
    }
}
