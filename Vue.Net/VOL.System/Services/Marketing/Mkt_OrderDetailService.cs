using VOL.System.IRepositories.Marketing;
using VOL.System.IServices.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Services.Marketing
{
    public partial class Mkt_OrderDetailService : ServiceBase<MktOrderDetail, IMkt_OrderDetailRepository>, IMkt_OrderDetailService, IDependency
    {
        public Mkt_OrderDetailService(IMkt_OrderDetailRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IMkt_OrderDetailService Instance
        {
           get { return AutofacContainerModule.GetService<IMkt_OrderDetailService>(); }
        }
    }
}
