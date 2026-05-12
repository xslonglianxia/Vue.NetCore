using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_SysGroupController : ApiBaseController<DC_SysGroupController, IDC_SysGroupService>
    {
        public DC_SysGroupController(IDC_SysGroupService service) : base(service)
        {
        }
    }
}
