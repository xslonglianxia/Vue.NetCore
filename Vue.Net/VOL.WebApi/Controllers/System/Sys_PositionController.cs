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
    [Route("api/Sys_Position")]
    [PermissionTable(Name = "Sys_Position")]
    public partial class Sys_PositionController : ApiBaseController<ISys_PositionService>
    {
        public Sys_PositionController(ISys_PositionService service)
        : base("System","System","Sys_Position", service)
        {
        }
    }
}
