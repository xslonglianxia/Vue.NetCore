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
    [Route("api/Sys_File")]
    [PermissionTable(Name = "Sys_File")]
    public partial class Sys_FileController : ApiBaseController<ISys_FileService>
    {
        public Sys_FileController(ISys_FileService service)
        : base("System","System","Sys_File", service)
        {
        }
    }
}
