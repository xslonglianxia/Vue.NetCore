using VOL.System.IRepositories.Marketing;
using VOL.System.IServices.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Services.Marketing
{
    public partial class Mkt_MemberDuplicateIpService : ServiceBase<MktMemberDuplicateIp, IMkt_MemberDuplicateIpRepository>, IMkt_MemberDuplicateIpService, IDependency
    {
        public Mkt_MemberDuplicateIpService(IMkt_MemberDuplicateIpRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IMkt_MemberDuplicateIpService Instance
        {
           get { return AutofacContainerModule.GetService<IMkt_MemberDuplicateIpService>(); }
        }
    }
}
