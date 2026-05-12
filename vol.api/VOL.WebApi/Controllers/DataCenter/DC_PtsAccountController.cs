using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_PtsAccountController : ApiBaseController<DC_PtsAccountController, IDC_PtsAccountService>
    {
        public DC_PtsAccountController(IDC_PtsAccountService service) : base(service)
        {
        }
    }
}
