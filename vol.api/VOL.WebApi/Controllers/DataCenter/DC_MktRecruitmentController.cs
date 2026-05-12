using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_MktRecruitmentController : ApiBaseController<DC_MktRecruitmentController, IDC_MktRecruitmentService>
    {
        public DC_MktRecruitmentController(IDC_MktRecruitmentService service) : base(service)
        {
        }
    }
}
