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
    [Route("api/Sys_Strategy")]
    [PermissionTable(Name = "Sys_Strategy")]
    public partial class Sys_StrategyController : ApiBaseController<ISys_StrategyService>
    {
        public Sys_StrategyController(ISys_StrategyService service)
        : base("System","System","Sys_Strategy", service)
        {
        }
    }
}
