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
    [Route("api/Mkt_Setting")]
    [PermissionTable(Name = "MktSetting")]
    public partial class Mkt_SettingController : ApiBaseController<IMkt_SettingService>
    {
        public Mkt_SettingController(IMkt_SettingService service)
        : base("Marketing","Marketing","MktSetting", service)
        {
        }
    }
}
