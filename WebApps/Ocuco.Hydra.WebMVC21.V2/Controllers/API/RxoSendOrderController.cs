using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ocuco.Application.Services.OcucoHub.LuxotticaRxoService;
using Ocuco.Application.Services.OcucoHub.LuxotticaRxoService.Dtos;
using Ocuco.Application.Services.OcucoHub.LuxotticaRxoService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocuco.Hydra.WebMVC21.V2.Controllers.API
{
    //
    // Core 2.0
    //

    [Route("api/[Controller]")]
    public class RxoSendOrderController : Controller
    {
        private readonly ILogger<RxoSendOrderController> logger;
        private readonly ILuxotticaRxoService luxotticaRxoSvc;

        public RxoSendOrderController(ILogger<RxoSendOrderController> logger,
                                       ILuxotticaRxoService luxotticaRxoSvc)
        {
            this.logger = logger;
            this.luxotticaRxoSvc = luxotticaRxoSvc;
        }

        [HttpPost]
        public IActionResult Post([FromBody]RxoSendOrderViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newSendOrderRequest = new RxoSendOrderRequest()
                    {
                        arg0 = model.OrderGroupID,

                        ACCOUNT = model.UserName,
                        PATIENT_FIRST_NAME = model.OrderGroupID,
                        PATIENT_LAST_NAME = model.DisplayID,
                        LENS_SALES_ARTICLE = model.LensCode,

                        //
                        // LENS R
                        //

                        LENS_R_TYPE = model.RightEye.Lens_Type,
                        LENS_R_SPHERE = model.RightEye.sphere,
                        LENS_R_CYLINDER = model.RightEye.cylinder,
                        LENS_R_AXIS = model.RightEye.axis,
                        LENS_R_DISTANCE = model.RightEye.DI,
                        LENS_R_ADD = model.RightEye.add,
                        LENS_R_SEG_HEIGHT = (model.RightEye.ProgHeight == null ? "" : model.RightEye.ProgHeight), 
                        LENS_R_OC_HEIGHT = (model.RightEye.MonoHeight == null ? "" : model.RightEye.MonoHeight),

                        //
                        // LENS L
                        //

                        LENS_L_TYPE = model.LeftEye.Lens_Type,
                        LENS_L_SPHERE = model.LeftEye.sphere,
                        LENS_L_CYLINDER = model.LeftEye.cylinder,
                        LENS_L_AXIS = model.LeftEye.axis,
                        LENS_L_DISTANCE = model.LeftEye.DI,
                        LENS_L_ADD = model.LeftEye.add,
                        LENS_L_SEG_HEIGHT = (model.LeftEye.ProgHeight == null ? "" : model.LeftEye.ProgHeight),
                        LENS_L_OC_HEIGHT = (model.LeftEye.MonoHeight == null ? "" : model.LeftEye.MonoHeight),

                        //
                        // FRAME
                        //
                        FRAME_UPC = model.FrameID,
                        FRAME_DBL = ""
                    };

                    // Invoke the Service
                    var RxoWsResponse = luxotticaRxoSvc.CallSendOrder(newSendOrderRequest);

                    return Ok(RxoWsResponse);
                }
                else
                {
                    // Show the errors
                    return BadRequest("SendOrder invalid model");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Luxottica SendOrder Error : {ex}");
                return BadRequest("SendOrder Error");
            }
        }




    }
}
