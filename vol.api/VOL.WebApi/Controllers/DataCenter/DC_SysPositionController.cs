using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_SysPositionController : ApiBaseController<DC_SysPositionController, IDC_SysPositionService>
    {
        public DC_SysPositionController(IDC_SysPositionService service) : base(service)
        {
        }
    }
}
