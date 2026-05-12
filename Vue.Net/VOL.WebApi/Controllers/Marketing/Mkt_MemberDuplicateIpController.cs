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
    [Route("api/Mkt_MemberDuplicateIp")]
    [PermissionTable(Name = "MktMemberDuplicateIp")]
    public partial class Mkt_MemberDuplicateIpController : ApiBaseController<IMkt_MemberDuplicateIpService>
    {
        public Mkt_MemberDuplicateIpController(IMkt_MemberDuplicateIpService service)
        : base("Marketing","Marketing","MktMemberDuplicateIp", service)
        {
        }
    }
}
