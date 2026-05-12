using VOL.System.IRepositories.System;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.System;

namespace VOL.System.Repositories.System
{
    public partial class Sys_OrgRepository : RepositoryBase<Sys_Org>, ISys_OrgRepository
    {
        public Sys_OrgRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static ISys_OrgRepository Instance
        {
            get { return AutofacContainerModule.GetService<ISys_OrgRepository>(); }
        }
    }
}
