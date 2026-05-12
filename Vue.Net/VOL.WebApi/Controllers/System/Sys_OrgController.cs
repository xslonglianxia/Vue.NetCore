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
    [Route("api/Sys_Org")]
    [PermissionTable(Name = "Sys_Org")]
    public partial class Sys_OrgController : ApiBaseController<ISys_OrgService>
    {
        public Sys_OrgController(ISys_OrgService service)
        : base("System","System","Sys_Org", service)
        {
        }
    }
}
