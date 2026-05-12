using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Entity.DomainModels.Marketing;
using VOL.System.IServices.Marketing;

namespace VOL.System.Controllers
{
    [Route("api/Mkt_MemberDateStatistic")]
    [PermissionTable(Name = "MktMemberDateStatistic")]
    public partial class Mkt_MemberDateStatisticController : ApiBaseController<IMkt_MemberDateStatisticService>
    {
        public Mkt_MemberDateStatisticController(IMkt_MemberDateStatisticService service)
        : base("Marketing","Marketing","MktMemberDateStatistic", service)
        {
        }
    }
}
