using Huach.Admin.IRepository.Basic;
using Huach.Admin.Models.Basic;

namespace Huach.Admin.Service.Basic
{    
    /// <summary>
    /// NewsService 
    /// </summary>
    public class NewsService: BaseService<News>  
    {    
		private readonly INewsRepository _newsRepository;
		public NewsService(INewsRepository newsRepository)
			:base(newsRepository)
		{
			_newsRepository = newsRepository;
		}
    }
}
    
