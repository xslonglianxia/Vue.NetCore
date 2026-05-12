using VOL.System.IRepositories.Marketing;
using VOL.System.IServices.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Services.Marketing
{
    public partial class Mkt_NoticeService : ServiceBase<MktNotice, IMkt_NoticeRepository>, IMkt_NoticeService, IDependency
    {
        public Mkt_NoticeService(IMkt_NoticeRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IMkt_NoticeService Instance
        {
           get { return AutofacContainerModule.GetService<IMkt_NoticeService>(); }
        }
    }
}
