using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_MktStatisticController : ApiBaseController<DC_MktStatisticController, IDC_MktStatisticService>
    {
        public DC_MktStatisticController(IDC_MktStatisticService service) : base(service)
        {
        }
    }
}
