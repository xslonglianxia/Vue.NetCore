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
    [Route("api/Mkt_WithdrawalKind")]
    [PermissionTable(Name = "MktWithdrawalKind")]
    public partial class Mkt_WithdrawalKindController : ApiBaseController<IMkt_WithdrawalKindService>
    {
        public Mkt_WithdrawalKindController(IMkt_WithdrawalKindService service)
        : base("Marketing","Marketing","MktWithdrawalKind", service)
        {
        }
    }
}
