using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_MktTradingFlowController : ApiBaseController<DC_MktTradingFlowController, IDC_MktTradingFlowService>
    {
        public DC_MktTradingFlowController(IDC_MktTradingFlowService service) : base(service)
        {
        }
    }
}
