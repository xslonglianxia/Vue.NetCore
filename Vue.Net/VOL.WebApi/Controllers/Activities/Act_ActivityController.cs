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
    [Route("api/Act_Activity")]
    [PermissionTable(Name = "ActActivity")]
    public partial class Act_ActivityController : ApiBaseController<IAct_ActivityService>
    {
        public Act_ActivityController(IAct_ActivityService service)
        : base("Activities","Activities","ActActivity", service)
        {
        }
    }
}
