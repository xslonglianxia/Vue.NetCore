using VOL.System.IRepositories.Marketing;
using VOL.System.IServices.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Services.Marketing
{
    public partial class Mkt_MemberStatisticService : ServiceBase<MktMemberStatistic, IMkt_MemberStatisticRepository>, IMkt_MemberStatisticService, IDependency
    {
        public Mkt_MemberStatisticService(IMkt_MemberStatisticRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IMkt_MemberStatisticService Instance
        {
           get { return AutofacContainerModule.GetService<IMkt_MemberStatisticService>(); }
        }
    }
}
