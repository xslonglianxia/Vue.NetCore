using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_MktBannerController : ApiBaseController<DC_MktBannerController, IDC_MktBannerService>
    {
        public DC_MktBannerController(IDC_MktBannerService service) : base(service)
        {
        }
    }
}
