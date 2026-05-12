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
    [Route("api/Mkt_Wallet")]
    [PermissionTable(Name = "MktWallet")]
    public partial class Mkt_WalletController : ApiBaseController<IMkt_WalletService>
    {
        public Mkt_WalletController(IMkt_WalletService service)
        : base("Marketing","Marketing","MktWallet", service)
        {
        }
    }
}
