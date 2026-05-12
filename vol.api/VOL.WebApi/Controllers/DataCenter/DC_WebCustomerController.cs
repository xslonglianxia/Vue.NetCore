using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_WebCustomerController : ApiBaseController<DC_WebCustomerController, IDC_WebCustomerService>
    {
        public DC_WebCustomerController(IDC_WebCustomerService service) : base(service)
        {
        }
    }
}
