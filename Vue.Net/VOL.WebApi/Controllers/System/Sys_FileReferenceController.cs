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
    [Route("api/Sys_FileReference")]
    [PermissionTable(Name = "Sys_FileReference")]
    public partial class Sys_FileReferenceController : ApiBaseController<ISys_FileReferenceService>
    {
        public Sys_FileReferenceController(ISys_FileReferenceService service)
        : base("System","System","Sys_FileReference", service)
        {
        }
    }
}
