using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_SysOperationLogController : ApiBaseController<DC_SysOperationLogController, IDC_SysOperationLogService>
    {
        public DC_SysOperationLogController(IDC_SysOperationLogService service) : base(service)
        {
        }
    }
}
