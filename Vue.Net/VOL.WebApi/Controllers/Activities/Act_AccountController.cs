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
    [Route("api/Act_Account")]
    [PermissionTable(Name = "ActAccount")]
    public partial class Act_AccountController : ApiBaseController<IAct_AccountService>
    {
        public Act_AccountController(IAct_AccountService service)
        : base("Activities","Activities","ActAccount", service)
        {
        }
    }
}
