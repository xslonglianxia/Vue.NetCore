using VOL.System.IRepositories.Marketing;
using VOL.System.IServices.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Services.Marketing
{
    public partial class Mkt_MemberService : ServiceBase<MktMember, IMkt_MemberRepository>, IMkt_MemberService, IDependency
    {
        public Mkt_MemberService(IMkt_MemberRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IMkt_MemberService Instance
        {
           get { return AutofacContainerModule.GetService<IMkt_MemberService>(); }
        }
    }
}
