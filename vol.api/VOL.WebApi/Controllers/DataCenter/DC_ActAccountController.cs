using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_ActAccountController : ApiBaseController<DC_ActAccountController, IDC_ActAccountService>
    {
        public DC_ActAccountController(IDC_ActAccountService service) : base(service)
        {
        }
    }
}
