using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_MktMemberLoginLogController : ApiBaseController<DC_MktMemberLoginLogController, IDC_MktMemberLoginLogService>
    {
        public DC_MktMemberLoginLogController(IDC_MktMemberLoginLogService service) : base(service)
        {
        }
    }
}
