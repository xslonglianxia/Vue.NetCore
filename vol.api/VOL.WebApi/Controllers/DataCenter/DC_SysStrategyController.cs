using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_SysStrategyController : ApiBaseController<DC_SysStrategyController, IDC_SysStrategyService>
    {
        public DC_SysStrategyController(IDC_SysStrategyService service) : base(service)
        {
        }
    }
}
