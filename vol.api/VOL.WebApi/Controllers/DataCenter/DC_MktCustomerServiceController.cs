using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_MktCustomerServiceController : ApiBaseController<DC_MktCustomerServiceController, IDC_MktCustomerServiceService>
    {
        public DC_MktCustomerServiceController(IDC_MktCustomerServiceService service) : base(service)
        {
        }
    }
}
