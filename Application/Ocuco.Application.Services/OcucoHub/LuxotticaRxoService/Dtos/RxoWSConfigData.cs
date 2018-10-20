using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocuco.Application.Services.OcucoHub.LuxotticaRxoService.Dtos
{
    public class RxoWSConfigData
    {
        public virtual string Address { get; set; }

        public virtual int HttpRequest { get; set; }

        public virtual bool BasicAuth { get; set; }

        public virtual string BasicAuthUsername { get; set; }

        public virtual string BasicAuthPassword { get; set; }

        public virtual string ORIGIN_NAME { get; set; }
    }
}
