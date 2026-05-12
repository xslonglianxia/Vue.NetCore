using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.DomainModels;
using VOL.DataCenter.IServices;

namespace VOL.WebApi.Controllers.DataCenter
{
    [Route("api/DC/[controller]/[action]")]
    public class DC_SysFileReferenceController : ApiBaseController<DC_SysFileReferenceController, IDC_SysFileReferenceService>
    {
        public DC_SysFileReferenceController(IDC_SysFileReferenceService service) : base(service)
        {
        }
    }
}
