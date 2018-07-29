using Huach.Admin.IRepository.Basic;
using Huach.Admin.Models.Basic;

namespace Huach.Admin.Service.Basic
{
    public class SysDictionaryService : ServiceBase<SysDictionary>
    {
        private readonly ISysDictionaryRepository _sysDictionaryRepository;
        public SysDictionaryService(ISysDictionaryRepository sysDictionaryRepository)
            :base(sysDictionaryRepository)
        {
            _sysDictionaryRepository = sysDictionaryRepository;
        }
    }
}
