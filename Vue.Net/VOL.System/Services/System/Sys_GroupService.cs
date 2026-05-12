using VOL.System.IRepositories.System;
using VOL.System.IServices.System;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.System;

namespace VOL.System.Services.System
{
    public partial class Sys_GroupService : ServiceBase<Sys_Group, ISys_GroupRepository>, ISys_GroupService, IDependency
    {
        public Sys_GroupService(ISys_GroupRepository repository)
             : base(repository)
        {
           Init(repository);
        }
        public static ISys_GroupService Instance
        {
           get { return AutofacContainerModule.GetService<ISys_GroupService>(); }
        }
    }
}
