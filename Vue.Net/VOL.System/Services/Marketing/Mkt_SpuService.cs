using VOL.System.IRepositories.Marketing;
using VOL.System.IServices.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Services.Marketing
{
    public partial class Mkt_SpuService : ServiceBase<MktSpu, IMkt_SpuRepository>, IMkt_SpuService, IDependency
    {
        public Mkt_SpuService(IMkt_SpuRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IMkt_SpuService Instance
        {
           get { return AutofacContainerModule.GetService<IMkt_SpuService>(); }
        }
    }
}
