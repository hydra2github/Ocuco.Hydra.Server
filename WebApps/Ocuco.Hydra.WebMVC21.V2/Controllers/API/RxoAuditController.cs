using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ocuco.Application.Services.OcucoHub.LuxotticaRxoAuditService;
using Ocuco.Application.Services.OcucoHub.LuxotticaRxoService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocuco.Hydra.WebMVC21.V2.Controllers.API
{
    [Route("/api/rxoaudit/{doorid}/details")]
    public class RxoAuditController : Controller
    {
        private readonly ILogger<RxoAuditController> logger;
        private readonly ILuxotticaRxoAuditService luxotticaRxoAuditSvc;

        public RxoAuditController(ILogger<RxoAuditController> logger,
                                  ILuxotticaRxoAuditService luxotticaRxoAuditSvc)
        {
            this.logger = logger;
            this.luxotticaRxoAuditSvc = luxotticaRxoAuditSvc;
        }

        [HttpGet]
        public IActionResult Get(string doorid)
        {
            if (doorid == null)
                return BadRequest();

            var doorActivity = luxotticaRxoAuditSvc.GetAuditRecordsViewModelByDoorID(doorid);

            if (doorActivity != null)
                return Ok(doorActivity);

            return NotFound();
        }


        //[HttpGet("{id}")]
        //public IActionResult Get(string doorid, string id)
        //{
        //    var order = repository.GetOrderById(orderId);
        //    if (order != null)
        //    {
        //        var item = order.Items.Where(i => i.Id == id).FirstOrDefault();
        //        if (item != null)
        //        {
        //            return Ok(mapper.Map<ArtOrderItem, ArtOrderItemViewModel>(item));
        //        }
        //    }
        //    return NotFound();
        //}
        

        [HttpGet("dateRange/{startdate:datetime}/{enddate:datetime}")]
        public IActionResult Get(string doorid, DateTime startdate, DateTime enddate)
        {
            if (doorid == null)
                return BadRequest();
            
            if (startdate > enddate)
            {
                return BadRequest("Invalid Date Range");
            }

            var doorActivity = luxotticaRxoAuditSvc.GetAuditRecordsViewModelByDoorID(doorid);
            if (doorActivity != null)
            {
                var doorActivityByDate = (from lst in doorActivity
                                          where lst.EventDate >= startdate && lst.EventDate <= enddate
                                          select lst);

                return Ok(doorActivityByDate);
            }

            return NotFound();
        }

    }
}
