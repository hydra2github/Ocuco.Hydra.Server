using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocuco.Application.Services.OcucoHub.LuxotticaRxoService.Dtos
{
    public class RxoSendOrderRequest
    {
        public virtual string arg0 { get; set; }
        public virtual string ORIGIN_NAME { get; set; }
        public virtual string DATE_REQUESTED { get; set; }
        public virtual string ACCOUNT { get; set; }
        public virtual string PATIENT_FIRST_NAME { get; set; }
        public virtual string PATIENT_LAST_NAME { get; set; }


        public virtual string LENS_SALES_ARTICLE { get; set; }


        // Lens R
        public virtual string LENS_R_TYPE { get; set; }
        public virtual string LENS_R_SPHERE { get; set; }
        public virtual string LENS_R_CYLINDER { get; set; }
        public virtual string LENS_R_AXIS { get; set; }
        public virtual string LENS_R_DISTANCE { get; set; }
        public virtual string LENS_R_ADD { get; set; }
        public virtual string LENS_R_SEG_HEIGHT { get; set; }
        public virtual string LENS_R_OC_HEIGHT { get; set; }
        public virtual string LENS_R_OPC { get; set; }


        // Lens L
        public virtual string LENS_L_TYPE { get; set; }
        public virtual string LENS_L_SPHERE { get; set; }
        public virtual string LENS_L_CYLINDER { get; set; }
        public virtual string LENS_L_AXIS { get; set; }
        public virtual string LENS_L_DISTANCE { get; set; }
        public virtual string LENS_L_ADD { get; set; }
        public virtual string LENS_L_SEG_HEIGHT { get; set; }
        public virtual string LENS_L_OC_HEIGHT { get; set; }
        public virtual string LENS_L_OPC { get; set; }


        public virtual string FRAME_UPC { get; set; }
        public virtual string FRAME_DBL { get; set; }
    }
}
