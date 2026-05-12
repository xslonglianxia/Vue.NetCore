using VOL.System.IRepositories.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Repositories.Marketing
{
    public partial class Mkt_SettingRepository : RepositoryBase<MktSetting>, IMkt_SettingRepository
    {
        public Mkt_SettingRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IMkt_SettingRepository Instance
        {
            get { return AutofacContainerModule.GetService<IMkt_SettingRepository>(); }
        }
    }
}
