using VOL.System.IRepositories.Marketing;
using VOL.System.IServices.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Services.Marketing
{
    public partial class Mkt_BannerService : ServiceBase<MktBanner, IMkt_BannerRepository>, IMkt_BannerService, IDependency
    {
        public Mkt_BannerService(IMkt_BannerRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IMkt_BannerService Instance
        {
           get { return AutofacContainerModule.GetService<IMkt_BannerService>(); }
        }
    }
}
