using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_MktWalletController : ApiBaseController<DC_MktWalletController, IDC_MktWalletService>
    {
        public DC_MktWalletController(IDC_MktWalletService service) : base(service)
        {
        }
    }
}
