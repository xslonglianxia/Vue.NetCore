using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_MktOrderDetailCommentService : ServiceBase<DC_MktOrderDetailComment, IDC_MktOrderDetailCommentRepository>
        , IDC_MktOrderDetailCommentService, IDependency
    {
        public static IDC_MktOrderDetailCommentService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktOrderDetailCommentService>(); } }
        }
    }
}
