using VOL.System.IRepositories.Marketing;
using VOL.System.IServices.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Services.Marketing
{
    public partial class Mkt_PerformanceStatisticService : ServiceBase<MktPerformanceStatistic, IMkt_PerformanceStatisticRepository>, IMkt_PerformanceStatisticService, IDependency
    {
        public Mkt_PerformanceStatisticService(IMkt_PerformanceStatisticRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IMkt_PerformanceStatisticService Instance
        {
           get { return AutofacContainerModule.GetService<IMkt_PerformanceStatisticService>(); }
        }
    }
}
