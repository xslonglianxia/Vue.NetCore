using VOL.System.IRepositories.System;
using VOL.System.IServices.System;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.System;

namespace VOL.System.Services.System
{
    public partial class Sys_FileService : ServiceBase<Sys_File, ISys_FileRepository>, ISys_FileService, IDependency
    {
        public Sys_FileService(ISys_FileRepository repository)
             : base(repository)
        {
           Init(repository);
        }
        public static ISys_FileService Instance
        {
           get { return AutofacContainerModule.GetService<ISys_FileService>(); }
        }
    }
}
