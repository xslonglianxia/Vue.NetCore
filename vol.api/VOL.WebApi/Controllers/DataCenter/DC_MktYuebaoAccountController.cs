using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_MktYuebaoAccountController : ApiBaseController<DC_MktYuebaoAccountController, IDC_MktYuebaoAccountService>
    {
        public DC_MktYuebaoAccountController(IDC_MktYuebaoAccountService service) : base(service)
        {
        }
    }
}
