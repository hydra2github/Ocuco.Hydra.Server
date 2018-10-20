using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ocuco.DataModel.Hydradb.Entities;
using Ocuco.DataModel.Hydradb.Repository;
using System;
using System.Collections.Generic;

namespace Ocuco.Hydra.WebMVC21.V2.Controllers
{
    ////
    //// Core 2.1 style
    ////

    //[Route("api/[Controller]")]
    //[ApiController]
    //[Produces("application/json")]
    //[ApiExplorerSettings(IgnoreApi = true)]
    //public class SampleProductsController : ControllerBase
    //{
    //    private readonly ISampleRepository repository;
    //    private readonly ILogger<SampleProductsController> logger;

    //    public SampleProductsController(ISampleRepository repository, ILogger<SampleProductsController> logger)
    //    {
    //        this.repository = repository;
    //        this.logger = logger;
    //    }

    //    // .NET Core 2.0

    //    //[HttpGet]
    //    //public IEnumerable<Product> Get()
    //    //{
    //    //    try
    //    //    {
    //    //        return _repository.GetAllProducts();
    //    //    }
    //    //    catch(Exception ex)
    //    //    {
    //    //        _logger.LogError($"Failed to get products: {ex}");
    //    //        return null;
    //    //    }            
    //    //}

    //    //[HttpGet]
    //    //public JsonResult Get()
    //    //{
    //    //    try
    //    //    {
    //    //        return Json(_repository.GetAllProducts());
    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        _logger.LogError($"Failed to get products: {ex}");
    //    //        return Json("Bad request");
    //    //    }
    //    //}

    //    //[HttpGet]
    //    //public IActionResult Get()
    //    //{
    //    //    try
    //    //    {
    //    //        return Ok(_repository.GetAllProducts());
    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        _logger.LogError($"Failed to get products: {ex}");
    //    //        return BadRequest("Failed to get products");
    //    //    }
    //    //}


    //    // .NET Core 2.1

    //    [HttpGet]
    //    [ProducesResponseType(200)]
    //    [ProducesResponseType(400)]
    //    public ActionResult<IEnumerable<ArtProduct>> Get()
    //    {
    //        try
    //        {
    //            return Ok(repository.GetAllArtProducts());
    //        }
    //        catch (Exception ex)
    //        {
    //            logger.LogError($"Error: {ex}");
    //            return BadRequest("Failure");
    //        }
    //    }


    //}


}
