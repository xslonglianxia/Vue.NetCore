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
    [Route("api/Act_Prize")]
    [PermissionTable(Name = "ActPrize")]
    public partial class Act_PrizeController : ApiBaseController<IAct_PrizeService>
    {
        public Act_PrizeController(IAct_PrizeService service)
        : base("Activities","Activities","ActPrize", service)
        {
        }
    }
}
