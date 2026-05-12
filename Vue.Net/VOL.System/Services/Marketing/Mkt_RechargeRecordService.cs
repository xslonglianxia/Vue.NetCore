using VOL.System.IRepositories.Marketing;
using VOL.System.IServices.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Services.Marketing
{
    public partial class Mkt_RechargeRecordService : ServiceBase<MktRechargeRecord, IMkt_RechargeRecordRepository>, IMkt_RechargeRecordService, IDependency
    {
        public Mkt_RechargeRecordService(IMkt_RechargeRecordRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IMkt_RechargeRecordService Instance
        {
           get { return AutofacContainerModule.GetService<IMkt_RechargeRecordService>(); }
        }
    }
}
