using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_MktPerformanceStatisticController : ApiBaseController<DC_MktPerformanceStatisticController, IDC_MktPerformanceStatisticService>
    {
        public DC_MktPerformanceStatisticController(IDC_MktPerformanceStatisticService service) : base(service)
        {
        }
    }
}
