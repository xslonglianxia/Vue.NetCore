using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_MktSettingRepository : RepositoryBase<DC_MktSetting> , IDC_MktSettingRepository
    {
        public DC_MktSettingRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_MktSettingRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktSettingRepository>(); } }
        }
    }
}
