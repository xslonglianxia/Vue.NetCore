using VOL.System.IRepositories.System;
using VOL.System.IServices.System;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.System;

namespace VOL.System.Services.System
{
    public partial class Sys_UserLoginLogService : ServiceBase<Sys_UserLoginLog, ISys_UserLoginLogRepository>, ISys_UserLoginLogService, IDependency
    {
        public Sys_UserLoginLogService(ISys_UserLoginLogRepository repository)
             : base(repository)
        {
           Init(repository);
        }
        public static ISys_UserLoginLogService Instance
        {
           get { return AutofacContainerModule.GetService<ISys_UserLoginLogService>(); }
        }
    }
}
