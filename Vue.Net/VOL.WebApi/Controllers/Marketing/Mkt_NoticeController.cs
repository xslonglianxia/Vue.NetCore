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
    [Route("api/Mkt_Notice")]
    [PermissionTable(Name = "MktNotice")]
    public partial class Mkt_NoticeController : ApiBaseController<IMkt_NoticeService>
    {
        public Mkt_NoticeController(IMkt_NoticeService service)
        : base("Marketing","Marketing","MktNotice", service)
        {
        }
    }
}
