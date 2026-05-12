using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_PtsGiftOrderController : ApiBaseController<DC_PtsGiftOrderController, IDC_PtsGiftOrderService>
    {
        public DC_PtsGiftOrderController(IDC_PtsGiftOrderService service) : base(service)
        {
        }
    }
}
