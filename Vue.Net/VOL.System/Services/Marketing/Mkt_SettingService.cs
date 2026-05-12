using VOL.System.IRepositories.Marketing;
using VOL.System.IServices.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Services.Marketing
{
    public partial class Mkt_SettingService : ServiceBase<MktSetting, IMkt_SettingRepository>, IMkt_SettingService, IDependency
    {
        public Mkt_SettingService(IMkt_SettingRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IMkt_SettingService Instance
        {
           get { return AutofacContainerModule.GetService<IMkt_SettingService>(); }
        }
    }
}
