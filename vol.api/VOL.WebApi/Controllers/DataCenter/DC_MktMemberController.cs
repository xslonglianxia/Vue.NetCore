using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_MktMemberController : ApiBaseController<DC_MktMemberController, IDC_MktMemberService>
    {
        public DC_MktMemberController(IDC_MktMemberService service) : base(service)
        {
        }
    }
}
