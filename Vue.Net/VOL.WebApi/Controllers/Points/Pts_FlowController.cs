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
    [Route("api/Pts_Flow")]
    [PermissionTable(Name = "PtsFlow")]
    public partial class Pts_FlowController : ApiBaseController<IPts_FlowService>
    {
        public Pts_FlowController(IPts_FlowService service)
        : base("Points","Points","PtsFlow", service)
        {
        }
    }
}
