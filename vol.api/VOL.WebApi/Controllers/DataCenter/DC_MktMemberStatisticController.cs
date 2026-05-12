using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_MktMemberStatisticController : ApiBaseController<DC_MktMemberStatisticController, IDC_MktMemberStatisticService>
    {
        public DC_MktMemberStatisticController(IDC_MktMemberStatisticService service) : base(service)
        {
        }
    }
}
