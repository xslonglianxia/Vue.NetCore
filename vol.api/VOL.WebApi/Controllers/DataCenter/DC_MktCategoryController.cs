using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_MktCategoryController : ApiBaseController<DC_MktCategoryController, IDC_MktCategoryService>
    {
        public DC_MktCategoryController(IDC_MktCategoryService service) : base(service)
        {
        }
    }
}
