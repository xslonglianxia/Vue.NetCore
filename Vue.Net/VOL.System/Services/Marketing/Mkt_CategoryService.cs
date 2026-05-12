using VOL.System.IRepositories.Marketing;
using VOL.System.IServices.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Services.Marketing
{
    public partial class Mkt_CategoryService : ServiceBase<MktCategory, IMkt_CategoryRepository>, IMkt_CategoryService, IDependency
    {
        public Mkt_CategoryService(IMkt_CategoryRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IMkt_CategoryService Instance
        {
           get { return AutofacContainerModule.GetService<IMkt_CategoryService>(); }
        }
    }
}
