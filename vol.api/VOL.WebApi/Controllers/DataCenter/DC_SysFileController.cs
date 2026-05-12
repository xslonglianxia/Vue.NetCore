using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_SysFileController : ApiBaseController<DC_SysFileController, IDC_SysFileService>
    {
        public DC_SysFileController(IDC_SysFileService service) : base(service)
        {
        }
    }
}
