using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_MktRechargeRecordController : ApiBaseController<DC_MktRechargeRecordController, IDC_MktRechargeRecordService>
    {
        public DC_MktRechargeRecordController(IDC_MktRechargeRecordService service) : base(service)
        {
        }
    }
}
