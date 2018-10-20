using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ocuco.Application.Services.OcucoHub.LuxotticaRxoService;
using Ocuco.Application.Services.OcucoHub.LuxotticaRxoService.Dtos;
using Ocuco.Application.Services.OcucoHub.LuxotticaRxoService.ViewModels;
using System;

namespace Ocuco.Hydra.WebMVC21.V2.Controllers.API
{
    //
    // Core 2.0
    //

    [Route("api/[Controller]")]
    public class RxoCheckFrameController : Controller
    {
        private readonly ILogger<RxoCheckFrameController> logger;
        private readonly ILuxotticaRxoService luxotticaRxoSvc;


        public RxoCheckFrameController(ILogger<RxoCheckFrameController> logger,
                                       ILuxotticaRxoService luxotticaRxoSvc)
        {
            this.logger = logger;
            this.luxotticaRxoSvc = luxotticaRxoSvc;
        }


        [HttpPost]
        public IActionResult Post([FromBody]RxoCheckFrameViewModel model)
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

                    return Ok(RxoWsResponse);
                }
                else
                {
                    // Show the errors
                    return BadRequest("CheckFrame invalid model");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Luxottica CheckFrame Error : {ex}");
                return BadRequest("CheckFrame Error");
            }            
        }


        //[HttpGet("{id}", Name = "GetContacts")]
        //public async Task<IActionResult> GetById(string id)
        //{
        //    //var item = await ContactsRepo.Find(id);
        //    //if (item == null)
        //    //{
        //    //    return NotFound();
        //    //}
        //    //return Ok(item);
        //    return Ok();
        //}

        //[HttpPost]
        //[Route("V2")]
        //public async Task<IActionResult> CheckFrame([FromBody] CheckFrameRequest model)
        //{
        //    //    //cancellationToken.ThrowIfCancellationRequested();
        //    //    //var response = await _editPatientServices.CreatePatient(CreateServiceRequest(newDetails));
        //    //    //return await response.BuildResponse(this, HttpStatusCode.Created);


        //    if (model == null)
        //    {
        //        return BadRequest();
        //    }
        //    //    await ContactsRepo.Add(item);
        //    var response = await rxoService.CallCheckFrameAsync(model);

        //    //return CreatedAtRoute("CheckFrame", new { Controller = "Contacts", id = item.MobilePhone }, item);

        //    return Ok();
        //}
    }
}
