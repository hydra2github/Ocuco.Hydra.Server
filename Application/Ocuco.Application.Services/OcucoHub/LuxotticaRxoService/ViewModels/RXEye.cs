using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocuco.Application.Services.OcucoHub.LuxotticaRxoService.ViewModels
{
    public class RXEye
    {
        public RXEye()
        {
            //default values
            sphere = "";
            cylinder = "";
            axis = "";
            DI = "";
            prism1 = "";
            base1 = "";
            prism2 = "";
            base2 = "";
            add = "";
            MonoHeight = "";
            ProgHeight = "";
        }

        public virtual string sphere { get; set; }

        public virtual string cylinder { get; set; }

        public virtual string axis { get; set; }

        public virtual string DI { get; set; }

        public virtual string prism1 { get; set; }

        public virtual string base1 { get; set; }

        public virtual string prism2 { get; set; }

        public virtual string base2 { get; set; }

        public virtual string add { get; set; }

        public virtual string MonoHeight { get; set; }

        public virtual string ProgHeight { get; set; }


        // Ref: ACU-14388  D.T.  20/07/2018 
        public virtual string Lens_Type { get; set; }
    }
}
