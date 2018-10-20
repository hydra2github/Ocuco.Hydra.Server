using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ocuco.Application.Services.OcucoHub.LuxotticaRxoAuditService;
using Ocuco.Application.Services.OcucoHub.LuxotticaRxoService;
using Ocuco.Application.Services.OcucoHub.LuxotticaRxoService.Dtos;
using Ocuco.Application.Services.OcucoHub.LuxotticaRxoService.ViewModels;
using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;

namespace Ocuco.Hydra.WebMVC21.V2.Controllers.MVC
{
    //
    // Core 2.0 style
    //

    [ApiExplorerSettings(IgnoreApi = true)]
    public class LuxRxoUIController : Controller
    {
        private readonly ILogger<LuxRxoUIController> logger;
        private readonly ILuxotticaRxoService luxotticaRxoSvc;
        private readonly ILuxotticaRxoAuditService luxotticaRxoAuditSvc;

        public LuxRxoUIController(ILogger<LuxRxoUIController> logger,
                                  ILuxotticaRxoService luxotticaRxoSvc,
                                  ILuxotticaRxoAuditService luxotticaRxoAuditSvc)
        {
            this.logger = logger;
            this.luxotticaRxoSvc = luxotticaRxoSvc;
            this.luxotticaRxoAuditSvc = luxotticaRxoAuditSvc;
        }



        public IActionResult Index()
        {
            return View();
        }



        [HttpGet("CheckFrame")]
        public IActionResult CheckFrame()
        {
            return View();
        }

        [HttpPost("CheckFrame")]
        public IActionResult CheckFrame([FromForm]RxoCheckFrameViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newCheckFrameRequest = new RxoCheckFrameRequest()
                    {
                        Kunnr = model.DoorNr,
                        Upc = model.FrameUpc
                    };
                    
                    // Invoke the Service
                    var RxoWsResponse = luxotticaRxoSvc.CallCheckFrame(newCheckFrameRequest);

                    ViewBag.UserMessage = RxoWsResponse;
                    ModelState.Clear();
                }
                else
                {
                    // Show the errors
                    ViewBag.UserMessage = "Error";
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Luxottica CheckFrame Error : {ex}");               
            }           
            return View();
        }
        


        [HttpGet("CheckOrder")]
        public IActionResult CheckOrder()
        {
            return View();
        }

        [HttpPost("CheckOrder")]
        public IActionResult CheckOrder([FromForm]RxoCheckOrderViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newCheckOrderRequest = new RxoCheckOrderRequest()
                    {
                        arg0 = model.OrderGroupID,

                        //ORIGIN_NAME = 

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
                        LENS_R_SEG_HEIGHT = model.RightEye.ProgHeight,
                        LENS_R_OC_HEIGHT = model.RightEye.MonoHeight,

                        //
                        // LENS L
                        //

                        LENS_L_TYPE = model.LeftEye.Lens_Type,
                        LENS_L_SPHERE = model.LeftEye.sphere,
                        LENS_L_CYLINDER = model.LeftEye.cylinder,
                        LENS_L_AXIS = model.LeftEye.axis,
                        LENS_L_DISTANCE = model.LeftEye.DI,
                        LENS_L_ADD = model.LeftEye.add,
                        LENS_L_SEG_HEIGHT = model.LeftEye.ProgHeight,
                        LENS_L_OC_HEIGHT = model.LeftEye.MonoHeight,

                        //
                        // FRAME
                        //
                        FRAME_UPC = model.FrameID,
                        FRAME_DBL = ""
                    };

                    // Invoke the Service
                    var RxoWsResponse = luxotticaRxoSvc.CallCheckOrder(newCheckOrderRequest);

                    ViewBag.UserMessage = RxoWsResponse;
                    ModelState.Clear();
                }
                else
                {
                    // Show the errors
                    ViewBag.UserMessage = "Error";
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Luxottica CheckOrder Error : {ex}");
            }
            return View();
        }



        [HttpGet("SendOrder")]
        public IActionResult SendOrder()
        {
            return View();
        }

        [HttpPost("SendOrder")]
        public IActionResult SendOrder([FromForm]RxoSendOrderViewModel model)
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
                        LENS_R_SEG_HEIGHT = model.RightEye.ProgHeight,
                        LENS_R_OC_HEIGHT = model.RightEye.MonoHeight,

                        //
                        // LENS L
                        //

                        LENS_L_TYPE = model.LeftEye.Lens_Type,
                        LENS_L_SPHERE = model.LeftEye.sphere,
                        LENS_L_CYLINDER = model.LeftEye.cylinder,
                        LENS_L_AXIS = model.LeftEye.axis,
                        LENS_L_DISTANCE = model.LeftEye.DI,
                        LENS_L_ADD = model.LeftEye.add,
                        LENS_L_SEG_HEIGHT = model.LeftEye.ProgHeight,
                        LENS_L_OC_HEIGHT = model.LeftEye.MonoHeight,

                        //
                        // FRAME
                        //
                        FRAME_UPC = model.FrameID,
                        FRAME_DBL = ""
                    };

                    // Invoke the Service
                    var RxoWsResponse = luxotticaRxoSvc.CallSendOrder(newSendOrderRequest);

                    ViewBag.UserMessage = RxoWsResponse;
                    ModelState.Clear();
                }
                else
                {
                    // Show the errors
                    ViewBag.UserMessage = "Error";
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Luxottica CheckOrder Error : {ex}");
            }
            return View();
        }



        [HttpGet("AuditDashboard")]
        public IActionResult AuditDashboard()
        {
            var rxoAuditSummary = luxotticaRxoAuditSvc.GetRxoAuditSummary();

            return View(rxoAuditSummary);
        }

        [HttpGet("AuditGrid")]
        public IActionResult AuditGrid()
        {
            return View();
        }

        public IActionResult LoadData()
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();

                // Skip number of Rows count  
                var start = Request.Form["start"].FirstOrDefault();

                // Paging Length 10,20  
                var length = Request.Form["length"].FirstOrDefault();

                // Sort Column Name  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();

                // Sort Column Direction (asc, desc)  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

                // Search Value from (Search box)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                //Paging Size (10, 20, 50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;

                int skip = start != null ? Convert.ToInt32(start) : 0;

                int recordsTotal = 0;

                // getting all Customer data  
                //var customerData = (from tempcustomer in _context.CustomerTB select tempcustomer);
                var customerData = luxotticaRxoAuditSvc.GetAuditDataForGrids();

                //Sorting  
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                }
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.DoorNumber == searchValue);
                }

                //total number of rows counts   
                recordsTotal = customerData.Count();
                //Paging   
                var data = customerData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception ex)
            {
                throw;
                return BadRequest(Json("123"));
            }
            return Ok(Json("123"));
        }
        
        public async Task<IActionResult> AuditRecordDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //
            var auditRecord = await luxotticaRxoAuditSvc.GetAuditRecordViewModelAsync(id);
            //if (movie == null)
            //{
            //    return NotFound();
            //}

            return View(auditRecord);
        }

        

        [HttpGet("About")]
        public IActionResult About()
        {

            


            return View();
        }

    }
}
