using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_MktOrderDetailController : ApiBaseController<DC_MktOrderDetailController, IDC_MktOrderDetailService>
    {
        public DC_MktOrderDetailController(IDC_MktOrderDetailService service) : base(service)
        {
        }
    }
}
