using VOL.System.IRepositories.System;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.System;

namespace VOL.System.Repositories.System
{
    public partial class Sys_GroupRepository : RepositoryBase<Sys_Group>, ISys_GroupRepository
    {
        public Sys_GroupRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static ISys_GroupRepository Instance
        {
            get { return AutofacContainerModule.GetService<ISys_GroupRepository>(); }
        }
    }
}
