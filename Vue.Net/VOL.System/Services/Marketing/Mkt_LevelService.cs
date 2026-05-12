using VOL.System.IRepositories.Marketing;
using VOL.System.IServices.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Services.Marketing
{
    public partial class Mkt_LevelService : ServiceBase<MktLevel, IMkt_LevelRepository>, IMkt_LevelService, IDependency
    {
        public Mkt_LevelService(IMkt_LevelRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IMkt_LevelService Instance
        {
           get { return AutofacContainerModule.GetService<IMkt_LevelService>(); }
        }
    }
}
