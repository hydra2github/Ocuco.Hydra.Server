using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocuco.Application.Services.OcucoHub.LuxotticaRxoService.ViewModels
{
    public class RxoCheckFrameViewModel
    {
        [Required]
        [MinLength(5)]
        public string DoorNr { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Too Long")]
        public string FrameUpc { get; set; }
    }
}
