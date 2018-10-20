using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ocuco.Application.Services.OcucoHub.CatalogueService;
using System;
using System.Collections.Generic;
using Ocuco.DataModel.Catalog.Entities;
using Ocuco.Application.Services.OcucoHub.CatalogueService.ViewModels;
using Microsoft.AspNetCore.Cors;

namespace Ocuco.Hydra.WebMVC21.V2.Controllers.API.Catalogue
{
    [Route("api/[Controller]")]
    [EnableCors("AllowAll")]
    public class CataloguesController : Controller
    {
        private readonly ILogger<CataloguesController> logger;
        private readonly ICatalogueService catalogueSvc;
        private readonly IMapper mapper;

        public CataloguesController(ILogger<CataloguesController> logger,
                                   ICatalogueService catalogueSvc,
                                   IMapper mapper)
        {
            this.logger = logger;
            this.catalogueSvc = catalogueSvc;
            this.mapper = mapper;
        }



        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var results = catalogueSvc.GetAllCatalogues();

                return Ok(mapper.Map<IEnumerable<Ocuco.DataModel.Catalog.Entities.Catalogue>, IEnumerable<CatalogueViewModel>>(results));
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get Catalogue Customers: {ex}");
                return BadRequest("Failed to get Catalogue Customers");
            }
        }


        [HttpGet("{customerId:int}")]
        public IActionResult GetCataloguesByCustomerId(int customerId)
        {
            if (customerId == null)
                return BadRequest();

            var results = catalogueSvc.GetCataloguesByCustomerId(customerId);

            if (results != null)
            {
                return Ok(mapper.Map<IEnumerable<Ocuco.DataModel.Catalog.Entities.Catalogue>, IEnumerable<CatalogueViewModel>>(results));
            }

            return NotFound();
        }


    }
}
