using Ocuco.DataModel.Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocuco.Application.Services.OcucoHub.CatalogueService.ViewModels
{
    public class CatalogueViewModel
    {
        public int Id { get; set; }

        public string CatalogueName { get; set; }

        public string Manufacturer { get; set; }
        
        public int? CatalogueType { get; set; }

        public int? CatalogueProductTypeId { get; set; }

        //public int? SupplierId { get; set; }
        //public int? ManufacturerId { get; set; }
        //public int? CatalogueSourceId { get; set; }
        //public int? CatalogueFormatId { get; set; }
        //public int? CatalogueMappingGroupId { get; set; }

        //public Manufacturer Manufacturer { get; set; }
    }
}
