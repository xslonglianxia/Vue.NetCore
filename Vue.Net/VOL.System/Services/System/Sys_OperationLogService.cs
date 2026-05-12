using VOL.System.IRepositories.System;
using VOL.System.IServices.System;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.System;

namespace VOL.System.Services.System
{
    public partial class Sys_OperationLogService : ServiceBase<Sys_OperationLog, ISys_OperationLogRepository>, ISys_OperationLogService, IDependency
    {
        public Sys_OperationLogService(ISys_OperationLogRepository repository)
             : base(repository)
        {
           Init(repository);
        }
        public static ISys_OperationLogService Instance
        {
           get { return AutofacContainerModule.GetService<ISys_OperationLogService>(); }
        }
    }
}
