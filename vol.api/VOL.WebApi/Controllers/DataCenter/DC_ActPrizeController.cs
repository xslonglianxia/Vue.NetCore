using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_ActPrizeController : ApiBaseController<DC_ActPrizeController, IDC_ActPrizeService>
    {
        public DC_ActPrizeController(IDC_ActPrizeService service) : base(service)
        {
        }
    }
}
