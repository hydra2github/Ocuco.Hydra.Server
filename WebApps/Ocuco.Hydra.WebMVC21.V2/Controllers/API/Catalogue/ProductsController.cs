using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ocuco.Application.Services.OcucoHub.CatalogueService;
using Ocuco.Application.Services.OcucoHub.CatalogueService.ViewModels;
using Ocuco.DataModel.Catalog.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ocuco.Hydra.WebMVC21.V2.Controllers.API.Catalogue
{
    [Route("/api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> logger;
        private readonly ICatalogueService catalogueSvc;
        private readonly IMapper mapper;

        public ProductsController(ILogger<ProductsController> logger,
                                 ICatalogueService catalogueSvc,
                                 IMapper mapper)
        {
            this.logger = logger;
            this.catalogueSvc = catalogueSvc;
            this.mapper = mapper;
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            if (id == null)
                return BadRequest();

            var result = catalogueSvc.GetProduct(id);

            if (result != null)
                return Ok(result);

            return NotFound();
        }

        //[HttpGet]
        //[Route("{catalogueid}")]
        //public IActionResult Get(int catalogueid)
        //{
        //    if (catalogueid == null)
        //        return BadRequest();

        //    var results = catalogueSvc.GetProductsByCatalogueId(catalogueid);

        //    if (results != null)
        //    {
        //        return Ok(mapper.Map<IEnumerable<Ocuco.DataModel.Catalog.Entities.Product>, IEnumerable<ProductViewModel>>(results));
        //    }

        //    return NotFound();
        //}

        //[HttpGet("{hubbrandid}")]
        //[Route("{catalogueId:int}/[action]/{hubbrandid}")]
        //[Route("{catalogueid}/{hubbrandid}")]
        //[HttpGet]
        //[Route("GetProductsByBrand/{catalogueid}/{hubbrandid}")]
        //public IActionResult GetProductsByBrand(int catalogueid, int hubbrandid)
        //{
        //    var results = catalogueSvc.GetProductsByCatalogueId(catalogueid);
        //    if (results != null)
        //    {
        //        var resultsbyBrand = results.Where(i => i.HubBrandId == hubbrandid).ToList();
        //        if (resultsbyBrand != null)
        //        {
        //            return Ok(mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(resultsbyBrand));
        //        }
        //    }
        //    return NotFound();
        //}

        //[HttpGet]
        //[Route("GetProductsBrandList/{catalogueid}")]
        //public IActionResult GetProductsBrandList(int catalogueid)
        //{
        //    var results = catalogueSvc.GetProductsBrandList(catalogueid);

        //    if (results != null)
        //    {
        //        return Ok(results);
        //    }

        //    return NotFound();
        //}

        [HttpGet]
        [Route("GetProductsBrandListForScreen/{catalogueid}")]
        public IActionResult GetProductsBrandListForScreen(int catalogueid)
        {
            var results = catalogueSvc.GetProductsBrandList(catalogueid);

            if (results != null)
            {
                return Ok(mapper.Map<IEnumerable<HubBrand>, IEnumerable<DropDownListViewModel>>(results));
            }

            return NotFound();
        }



        [HttpGet]
        [Route("GetProductsByBrandForScreen/{catalogueid}/{hubbrandid}")]
        public IActionResult GetProductsByBrandForScreen(int catalogueid, int hubbrandid)
        {
            var results = catalogueSvc.GetProductsByCatalogueId(catalogueid);
            if (results != null)
            {
                var resultsbyBrand = results.Where(i => i.HubBrandId == hubbrandid).ToList();
                if (resultsbyBrand != null)
                {
                    return Ok(mapper.Map<IEnumerable<Product>, IEnumerable<DropDownListViewModel>>(resultsbyBrand));
                }
            }
            return NotFound();
        }






        //[HttpGet("{hubbrandid}")]
        //[Route("{catalogueId:int}/[action]/{hubbrandid}")]

        //[HttpGet]
        //[Route("/photos/download")]
        //[SwaggerOperation("Photo Download")]

        //[HttpGet]
        ////[Route("GetProductsByBrand/{catalogueid}/{hubbrandid}")]
        //[Route("{upc}/Image")]
        //public async Task<IActionResult> GetProductImage(string upc)
        //{
        //    var results = catalogueSvc.GetProductImageByUPC(upc);
        //    //if (results != null)
        //    //{
        //    //    var resultsbyBrand = results.Where(i => i.HubBrandId == hubbrandid).ToList();
        //    //    if (resultsbyBrand != null)
        //    //    {
        //    //        return Ok(mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(resultsbyBrand));
        //    //    }
        //    //}
        //    return NotFound();
        //}


        [HttpGet]
        [Route("{upc}/Image")]
        public async Task<IActionResult> GetProductImageAsync(string upc)
        {
            var streamTask = catalogueSvc.GetProductImageByUPCAsync(upc);

            Stream stream = streamTask.Result;

            return await Task.Run(() => File(stream, "image/jpeg"));
        }


        //[HttpGet]
        //[Route("{upc}/ImageV2")]
        //public IActionResult GetProductImage(string upc)
        //{
        //    //return new PhysicalFile(@"C:\test.jpg", "image/jpeg");

        //    //var results = catalogueSvc.GetProductImageByUPC(upc);

        //    return Ok();
        //}




    }
}
