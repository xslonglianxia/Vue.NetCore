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
    [Route("api/Sys_Group")]
    [PermissionTable(Name = "Sys_Group")]
    public partial class Sys_GroupController : ApiBaseController<ISys_GroupService>
    {
        public Sys_GroupController(ISys_GroupService service)
        : base("System","System","Sys_Group", service)
        {
        }
    }
}
