using VOL.DataCenter.IRepositories;
using VOL.DataCenter.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.DataCenter.Services
{
    public partial class DC_MktMemberService : ServiceBase<DC_MktMember, IDC_MktMemberRepository>
        , IDC_MktMemberService, IDependency
    {
        public static IDC_MktMemberService Instance
        {
            get { return AutofacContainerModule.GetService<IDC_MktMemberService>(); } }
        }
    }
}
