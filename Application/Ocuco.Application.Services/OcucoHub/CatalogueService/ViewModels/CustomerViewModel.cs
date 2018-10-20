using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocuco.Application.Services.OcucoHub.CatalogueService.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }

        // 10-OCT-2018
        public string SubscriptionKey { get; set; }
    }
}
