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
    [Route("api/Mkt_Category")]
    [PermissionTable(Name = "MktCategory")]
    public partial class Mkt_CategoryController : ApiBaseController<IMkt_CategoryService>
    {
        public Mkt_CategoryController(IMkt_CategoryService service)
        : base("Marketing","Marketing","MktCategory", service)
        {
        }
    }
}
