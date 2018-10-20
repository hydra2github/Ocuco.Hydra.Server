using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocuco.Application.Services.OcucoHub.LuxotticaRxoService.ViewModels
{
    public class RxoSendOrderViewModel
    {
        public RxoSendOrderViewModel()
        {
            RightEye = new RXEye();
            LeftEye = new RXEye();

            //default values
            UserName = "";
            Password = "";
            PracticeID = "";
            LocationID = "";
            ChartItemID = "";
            OrderGroupID = "";
            DisplayID = "";
            FrameID = "";
            LensCode = "";
        }
          
        // Request data

        public virtual string UserName { get; set; }

        public virtual string Password { get; set; }

        public virtual string PracticeID { get; set; }

        public virtual string LocationID { get; set; }

        public virtual string ChartItemID { get; set; }

        public virtual string OrderGroupID { get; set; }

        public virtual string DisplayID { get; set; }

        public virtual string FrameID { get; set; }

        public virtual string LensCode { get; set; }


        public RXEye RightEye;


        public RXEye LeftEye;
    }
}
