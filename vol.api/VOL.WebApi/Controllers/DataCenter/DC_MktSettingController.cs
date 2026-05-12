using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_MktSettingController : ApiBaseController<DC_MktSettingController, IDC_MktSettingService>
    {
        public DC_MktSettingController(IDC_MktSettingService service) : base(service)
        {
        }
    }
}
