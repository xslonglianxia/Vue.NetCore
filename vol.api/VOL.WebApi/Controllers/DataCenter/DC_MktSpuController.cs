using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_MktSpuController : ApiBaseController<DC_MktSpuController, IDC_MktSpuService>
    {
        public DC_MktSpuController(IDC_MktSpuService service) : base(service)
        {
        }
    }
}
