using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_MktLevelController : ApiBaseController<DC_MktLevelController, IDC_MktLevelService>
    {
        public DC_MktLevelController(IDC_MktLevelService service) : base(service)
        {
        }
    }
}
