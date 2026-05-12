using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_ActPartnerController : ApiBaseController<DC_ActPartnerController, IDC_ActPartnerService>
    {
        public DC_ActPartnerController(IDC_ActPartnerService service) : base(service)
        {
        }
    }
}
