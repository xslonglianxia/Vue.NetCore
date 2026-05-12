using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Entity.DomainModels.System;
using VOL.System.IServices.System;

namespace VOL.System.Controllers
{
    [Route("api/Sys_OperationLog")]
    [PermissionTable(Name = "Sys_OperationLog")]
    public partial class Sys_OperationLogController : ApiBaseController<ISys_OperationLogService>
    {
        public Sys_OperationLogController(ISys_OperationLogService service)
        : base("System","System","Sys_OperationLog", service)
        {
        }
    }
}
