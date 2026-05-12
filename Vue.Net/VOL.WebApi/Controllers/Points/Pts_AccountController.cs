using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Entity.DomainModels.Points;
using VOL.System.IServices.Points;

namespace VOL.System.Controllers
{
    [Route("api/Pts_Account")]
    [PermissionTable(Name = "PtsAccount")]
    public partial class Pts_AccountController : ApiBaseController<IPts_AccountService>
    {
        public Pts_AccountController(IPts_AccountService service)
        : base("Points","Points","PtsAccount", service)
        {
        }
    }
}
