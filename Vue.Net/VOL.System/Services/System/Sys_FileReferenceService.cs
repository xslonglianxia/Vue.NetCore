using VOL.System.IRepositories.System;
using VOL.System.IServices.System;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.System;

namespace VOL.System.Services.System
{
    public partial class Sys_FileReferenceService : ServiceBase<Sys_FileReference, ISys_FileReferenceRepository>, ISys_FileReferenceService, IDependency
    {
        public Sys_FileReferenceService(ISys_FileReferenceRepository repository)
             : base(repository)
        {
           Init(repository);
        }
        public static ISys_FileReferenceService Instance
        {
           get { return AutofacContainerModule.GetService<ISys_FileReferenceService>(); }
        }
    }
}
