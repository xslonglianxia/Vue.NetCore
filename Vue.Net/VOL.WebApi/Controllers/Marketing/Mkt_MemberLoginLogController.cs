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
    [Route("api/Mkt_MemberLoginLog")]
    [PermissionTable(Name = "MktMemberLoginLog")]
    public partial class Mkt_MemberLoginLogController : ApiBaseController<IMkt_MemberLoginLogService>
    {
        public Mkt_MemberLoginLogController(IMkt_MemberLoginLogService service)
        : base("Marketing","Marketing","MktMemberLoginLog", service)
        {
        }
    }
}
