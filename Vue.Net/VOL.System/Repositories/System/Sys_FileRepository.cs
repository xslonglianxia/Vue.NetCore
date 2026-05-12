using VOL.System.IRepositories.System;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.System;

namespace VOL.System.Repositories.System
{
    public partial class Sys_FileRepository : RepositoryBase<Sys_File>, ISys_FileRepository
    {
        public Sys_FileRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static ISys_FileRepository Instance
        {
            get { return AutofacContainerModule.GetService<ISys_FileRepository>(); }
        }
    }
}
