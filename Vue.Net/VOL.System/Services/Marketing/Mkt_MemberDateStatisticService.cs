using VOL.System.IRepositories.Marketing;
using VOL.System.IServices.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Services.Marketing
{
    public partial class Mkt_MemberDateStatisticService : ServiceBase<MktMemberDateStatistic, IMkt_MemberDateStatisticRepository>, IMkt_MemberDateStatisticService, IDependency
    {
        public Mkt_MemberDateStatisticService(IMkt_MemberDateStatisticRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IMkt_MemberDateStatisticService Instance
        {
           get { return AutofacContainerModule.GetService<IMkt_MemberDateStatisticService>(); }
        }
    }
}
