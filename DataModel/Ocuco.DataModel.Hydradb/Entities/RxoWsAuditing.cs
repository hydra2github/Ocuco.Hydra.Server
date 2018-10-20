using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocuco.DataModel.Hydradb.Entities
{
    public class RxoWsAuditing
    {
        public int Id { get; set; }
        public RxoDoor LuxotticaDoor { get; set; }
        public string DoorNumber { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventDate { get; set; }
        public string EventStatus { get; set; }
        public string EventRequest { get; set; }
        public string EventResponse { get; set; }
    }
}
