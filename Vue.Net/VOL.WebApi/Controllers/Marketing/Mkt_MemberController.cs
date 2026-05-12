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
    [Route("api/Mkt_Member")]
    [PermissionTable(Name = "MktMember")]
    public partial class Mkt_MemberController : ApiBaseController<IMkt_MemberService>
    {
        public Mkt_MemberController(IMkt_MemberService service)
        : base("Marketing","Marketing","MktMember", service)
        {
        }
    }
}
