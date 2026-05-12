using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_MktWithdrawalAccountApproveLogController : ApiBaseController<DC_MktWithdrawalAccountApproveLogController, IDC_MktWithdrawalAccountApproveLogService>
    {
        public DC_MktWithdrawalAccountApproveLogController(IDC_MktWithdrawalAccountApproveLogService service) : base(service)
        {
        }
    }
}
