using Huach.Admin.IRepository.Business;
using Huach.Admin.Models.Business;

namespace Huach.Admin.Service.Business
{    
    /// <summary>
    /// CompanyService 
    /// </summary>
    public class CompanyService: ServiceBase<Company>  
    {    
		private readonly ICompanyRepository _companyRepository;
		public CompanyService(ICompanyRepository companyRepository)
			:base(companyRepository)
		{
			_companyRepository = companyRepository;
		}
    }
}
    
