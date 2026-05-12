using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_MktWithdrawalRecordController : ApiBaseController<DC_MktWithdrawalRecordController, IDC_MktWithdrawalRecordService>
    {
        public DC_MktWithdrawalRecordController(IDC_MktWithdrawalRecordService service) : base(service)
        {
        }
    }
}
