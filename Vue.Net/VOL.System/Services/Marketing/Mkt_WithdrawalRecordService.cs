using VOL.System.IRepositories.Marketing;
using VOL.System.IServices.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Services.Marketing
{
    public partial class Mkt_WithdrawalRecordService : ServiceBase<MktWithdrawalRecord, IMkt_WithdrawalRecordRepository>, IMkt_WithdrawalRecordService, IDependency
    {
        public Mkt_WithdrawalRecordService(IMkt_WithdrawalRecordRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IMkt_WithdrawalRecordService Instance
        {
           get { return AutofacContainerModule.GetService<IMkt_WithdrawalRecordService>(); }
        }
    }
}
