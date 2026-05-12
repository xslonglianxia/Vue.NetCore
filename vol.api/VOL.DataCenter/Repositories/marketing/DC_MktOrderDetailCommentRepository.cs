using VOL.DataCenter.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Repositories
{
    public partial class DC_MktOrderDetailCommentRepository : RepositoryBase<DC_MktOrderDetailComment> , IDC_MktOrderDetailCommentRepository
    {
        public DC_MktOrderDetailCommentRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static IDC_MktOrderDetailCommentRepository Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktOrderDetailCommentRepository>(); } }
        }
    }
}
