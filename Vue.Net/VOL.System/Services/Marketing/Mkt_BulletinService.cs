using VOL.System.IRepositories.Marketing;
using VOL.System.IServices.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Services.Marketing
{
    public partial class Mkt_BulletinService : ServiceBase<MktBulletin, IMkt_BulletinRepository>, IMkt_BulletinService, IDependency
    {
        public Mkt_BulletinService(IMkt_BulletinRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IMkt_BulletinService Instance
        {
           get { return AutofacContainerModule.GetService<IMkt_BulletinService>(); }
        }
    }
}
