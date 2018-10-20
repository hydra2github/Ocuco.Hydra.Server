using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ocuco.Application.Services.OcucoHub.CatalogueService;
using Ocuco.Application.Services.OcucoHub.CatalogueService.ViewModels;
using Ocuco.DataModel.Catalog.Entities;
using System;
using System.Collections.Generic;

namespace Ocuco.Hydra.WebMVC21.V2.Controllers.API.Catalogue
{
    [Route("api/[Controller]")]
    //[ApiExplorerSettings(GroupName = "Catalogue")]
    public class CustomersController : Controller
    {
        private readonly ILogger<CustomersController> logger;
        private readonly ICatalogueService catalogueSvc;
        private readonly IMapper mapper;

        public CustomersController(ILogger<CustomersController> logger,
                                   ICatalogueService catalogueSvc,
                                   IMapper mapper)
        {
            this.logger = logger;
            this.catalogueSvc = catalogueSvc;
            this.mapper = mapper;
        }

        //[HttpGet]
        //public IActionResult Get(bool includeItems = true)
        //{
        //    try
        //    {
        //        //return Ok(repository.GetAllOrders());
        //        //return Ok(mapper.Map<IEnumerable<ArtOrder>, IEnumerable<ArtOrderViewModel>>(repository.GetAllOrders()));

        //        var results = repository.GetAllOrders(includeItems);

        //        return Ok(mapper.Map<IEnumerable<ArtOrder>, IEnumerable<ArtOrderViewModel>>(results));
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError($"Failed to get orders: {ex}");
        //        return BadRequest("Failed to get orders");
        //    }
        //}



        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var results = catalogueSvc.GetAllCustomers();

                return Ok(mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(results));
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get Catalogue Customers: {ex}");
                return BadRequest("Failed to get Catalogue Customers");
            }
        }


        [HttpGet("{subscriptionKey}")]
        public IActionResult GetbySubscritionKey(string subscriptionKey)
        {
            if (subscriptionKey == null)
                return BadRequest();

            var results = catalogueSvc.GetCustomersBySubscriptionKey(subscriptionKey);

            if (results != null)
            {
                return Ok(results);
            }

            return NotFound();
        }




    }
}
