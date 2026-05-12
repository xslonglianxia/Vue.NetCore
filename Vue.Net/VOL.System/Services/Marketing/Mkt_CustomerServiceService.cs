using VOL.System.IRepositories.Marketing;
using VOL.System.IServices.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Services.Marketing
{
    public partial class Mkt_CustomerServiceService : ServiceBase<MktCustomerService, IMkt_CustomerServiceRepository>, IMkt_CustomerServiceService, IDependency
    {
        public Mkt_CustomerServiceService(IMkt_CustomerServiceRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IMkt_CustomerServiceService Instance
        {
           get { return AutofacContainerModule.GetService<IMkt_CustomerServiceService>(); }
        }
    }
}
