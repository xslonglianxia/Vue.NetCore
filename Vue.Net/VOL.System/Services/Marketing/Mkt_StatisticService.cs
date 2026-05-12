using VOL.System.IRepositories.Marketing;
using VOL.System.IServices.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Services.Marketing
{
    public partial class Mkt_StatisticService : ServiceBase<MktStatistic, IMkt_StatisticRepository>, IMkt_StatisticService, IDependency
    {
        public Mkt_StatisticService(IMkt_StatisticRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IMkt_StatisticService Instance
        {
           get { return AutofacContainerModule.GetService<IMkt_StatisticService>(); }
        }
    }
}
