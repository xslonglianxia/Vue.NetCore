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
    [Route("api/Mkt_MemberStatistic")]
    [PermissionTable(Name = "MktMemberStatistic")]
    public partial class Mkt_MemberStatisticController : ApiBaseController<IMkt_MemberStatisticService>
    {
        public Mkt_MemberStatisticController(IMkt_MemberStatisticService service)
        : base("Marketing","Marketing","MktMemberStatistic", service)
        {
        }
    }
}
