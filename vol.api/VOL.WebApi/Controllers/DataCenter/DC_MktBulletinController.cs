using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_MktBulletinController : ApiBaseController<DC_MktBulletinController, IDC_MktBulletinService>
    {
        public DC_MktBulletinController(IDC_MktBulletinService service) : base(service)
        {
        }
    }
}
