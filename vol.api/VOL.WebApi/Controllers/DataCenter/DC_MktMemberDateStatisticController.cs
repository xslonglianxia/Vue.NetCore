using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_MktMemberDateStatisticController : ApiBaseController<DC_MktMemberDateStatisticController, IDC_MktMemberDateStatisticService>
    {
        public DC_MktMemberDateStatisticController(IDC_MktMemberDateStatisticService service) : base(service)
        {
        }
    }
}
