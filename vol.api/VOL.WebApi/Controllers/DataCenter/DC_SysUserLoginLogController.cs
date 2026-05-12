using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_SysUserLoginLogController : ApiBaseController<DC_SysUserLoginLogController, IDC_SysUserLoginLogService>
    {
        public DC_SysUserLoginLogController(IDC_SysUserLoginLogService service) : base(service)
        {
        }
    }
}
