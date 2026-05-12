using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_MktOrderDetailCommentController : ApiBaseController<DC_MktOrderDetailCommentController, IDC_MktOrderDetailCommentService>
    {
        public DC_MktOrderDetailCommentController(IDC_MktOrderDetailCommentService service) : base(service)
        {
        }
    }
}
