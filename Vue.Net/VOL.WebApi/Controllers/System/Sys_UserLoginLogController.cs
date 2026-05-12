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
    [Route("api/Sys_UserLoginLog")]
    [PermissionTable(Name = "Sys_UserLoginLog")]
    public partial class Sys_UserLoginLogController : ApiBaseController<ISys_UserLoginLogService>
    {
        public Sys_UserLoginLogController(ISys_UserLoginLogService service)
        : base("System","System","Sys_UserLoginLog", service)
        {
        }
    }
}
