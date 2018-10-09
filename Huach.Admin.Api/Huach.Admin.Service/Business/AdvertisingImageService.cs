using Huach.Admin.IRepository.Business;
using Huach.Admin.Models.Business;

namespace Huach.Admin.Service.Business
{    
    /// <summary>
    /// AdvertisingImageService 
    /// </summary>
    public class AdvertisingImageService: BaseService<AdvertisingImage>  
    {    
		private readonly IAdvertisingImageRepository _advertisingImageRepository;
		public AdvertisingImageService(IAdvertisingImageRepository advertisingImageRepository)
			:base(advertisingImageRepository)
		{
			_advertisingImageRepository = advertisingImageRepository;
		}
    }
}
    
