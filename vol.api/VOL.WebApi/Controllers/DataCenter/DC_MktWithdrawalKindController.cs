using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_MktWithdrawalKindController : ApiBaseController<DC_MktWithdrawalKindController, IDC_MktWithdrawalKindService>
    {
        public DC_MktWithdrawalKindController(IDC_MktWithdrawalKindService service) : base(service)
        {
        }
    }
}
