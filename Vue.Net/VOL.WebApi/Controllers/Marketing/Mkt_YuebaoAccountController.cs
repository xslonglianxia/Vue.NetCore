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
    [Route("api/Mkt_YuebaoAccount")]
    [PermissionTable(Name = "MktYuebaoAccount")]
    public partial class Mkt_YuebaoAccountController : ApiBaseController<IMkt_YuebaoAccountService>
    {
        public Mkt_YuebaoAccountController(IMkt_YuebaoAccountService service)
        : base("Marketing","Marketing","MktYuebaoAccount", service)
        {
        }
    }
}
