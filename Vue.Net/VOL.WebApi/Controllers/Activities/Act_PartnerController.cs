using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Entity.DomainModels.Activities;
using VOL.System.IServices.Activities;

namespace VOL.System.Controllers
{
    [Route("api/Act_Partner")]
    [PermissionTable(Name = "ActPartner")]
    public partial class Act_PartnerController : ApiBaseController<IAct_PartnerService>
    {
        public Act_PartnerController(IAct_PartnerService service)
        : base("Activities","Activities","ActPartner", service)
        {
        }
    }
}
