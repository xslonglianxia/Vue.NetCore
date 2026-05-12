using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_MktMemberRepository : RepositoryBase<DC_MktMember> , IDC_MktMemberRepository
    {
        public DC_MktMemberRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_MktMemberRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktMemberRepository>(); } }
        }
    }
}
