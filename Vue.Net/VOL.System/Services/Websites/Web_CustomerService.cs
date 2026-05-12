using VOL.System.IRepositories.Websites;
using VOL.System.IServices.Websites;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Websites;

namespace VOL.System.Services.Websites
{
    public partial class Web_CustomerService : ServiceBase<WebCustomer, IWeb_CustomerRepository>, IWeb_CustomerService, IDependency
    {
        public Web_CustomerService(IWeb_CustomerRepository repository)
             : base(repository)
        {
           Init(repository);
        }
        public static IWeb_CustomerService Instance
        {
           get { return AutofacContainerModule.GetService<IWeb_CustomerService>(); }
        }
    }
}
