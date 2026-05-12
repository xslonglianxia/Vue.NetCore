using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_AppResourceController : ApiBaseController<DC_AppResourceController, IDC_AppResourceService>
    {
        public DC_AppResourceController(IDC_AppResourceService service) : base(service)
        {
        }
    }
}
