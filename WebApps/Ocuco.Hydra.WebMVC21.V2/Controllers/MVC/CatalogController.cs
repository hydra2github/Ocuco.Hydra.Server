using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ocuco.Hydra.WebMVC21.V2.Controllers.MVC
{
    
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CatalogController : Controller
    {
        private readonly ILogger<CatalogController> logger;

        public CatalogController(ILogger<CatalogController> logger)
        {
            this.logger = logger;
        }
    }
}
