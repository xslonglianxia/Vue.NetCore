using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Entity.DomainModels.Websites;
using VOL.System.IServices.Websites;

namespace VOL.System.Controllers
{
    [Route("api/Web_Customer")]
    [PermissionTable(Name = "WebCustomer")]
    public partial class Web_CustomerController : ApiBaseController<IWeb_CustomerService>
    {
        public Web_CustomerController(IWeb_CustomerService service)
        : base("Websites","Websites","WebCustomer", service)
        {
        }
    }
}
