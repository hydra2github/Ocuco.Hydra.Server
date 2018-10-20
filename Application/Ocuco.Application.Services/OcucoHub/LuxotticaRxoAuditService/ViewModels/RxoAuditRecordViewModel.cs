using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocuco.Application.Services.OcucoHub.LuxotticaRxoAuditService.ViewModels
{
    public class RxoAuditRecordViewModel
    {
        public int AuditID { get; set; }
        public string DoorNumber { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
    }
}
