using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_MktYuebaoTradingFlowController : ApiBaseController<DC_MktYuebaoTradingFlowController, IDC_MktYuebaoTradingFlowService>
    {
        public DC_MktYuebaoTradingFlowController(IDC_MktYuebaoTradingFlowService service) : base(service)
        {
        }
    }
}
