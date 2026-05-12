using VOL.System.IRepositories.System;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.System;

namespace VOL.System.Repositories.System
{
    public partial class Sys_FileReferenceRepository : RepositoryBase<Sys_FileReference>, ISys_FileReferenceRepository
    {
        public Sys_FileReferenceRepository(VOLContext dbContext)
        : base(dbContext)
        {
        }
        public static ISys_FileReferenceRepository Instance
        {
            get { return AutofacContainerModule.GetService<ISys_FileReferenceRepository>(); }
        }
    }
}
