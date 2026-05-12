using VOL.System.IRepositories.System;
using VOL.System.IServices.System;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.System;

namespace VOL.System.Services.System
{
    public partial class Sys_OrgService : ServiceBase<Sys_Org, ISys_OrgRepository>, ISys_OrgService, IDependency
    {
        public Sys_OrgService(ISys_OrgRepository repository)
             : base(repository)
        {
           Init(repository);
        }
        public static ISys_OrgService Instance
        {
           get { return AutofacContainerModule.GetService<ISys_OrgService>(); }
        }
    }
}
