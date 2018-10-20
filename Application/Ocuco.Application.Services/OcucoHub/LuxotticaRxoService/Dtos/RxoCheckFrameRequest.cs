using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocuco.Application.Services.OcucoHub.LuxotticaRxoService.Dtos
{
    public class RxoCheckFrameRequest
    {
        [Required]
        public string Kunnr { get; set; }
        [Required]
        public string Upc { get; set; }
    }
}
