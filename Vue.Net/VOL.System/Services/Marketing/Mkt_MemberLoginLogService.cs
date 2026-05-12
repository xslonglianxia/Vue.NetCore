using VOL.System.IRepositories.Marketing;
using VOL.System.IServices.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Services.Marketing
{
    public partial class Mkt_MemberLoginLogService : ServiceBase<MktMemberLoginLog, IMkt_MemberLoginLogRepository>, IMkt_MemberLoginLogService, IDependency
    {
        public Mkt_MemberLoginLogService(IMkt_MemberLoginLogRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IMkt_MemberLoginLogService Instance
        {
           get { return AutofacContainerModule.GetService<IMkt_MemberLoginLogService>(); }
        }
    }
}
