using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocuco.Application.Services.OcucoHub.CatalogueService.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public int? CatalogueId { get; set; }
        public string Upc { get; set; }
        public string Skucode { get; set; }
        public string ArticleName { get; set; }

        public string AzureImage { get; set; }
        public string AzureImageHD { get; set; }
        public string AzureImageThumb { get; set; }
    }
}
