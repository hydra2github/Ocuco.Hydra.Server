namespace Ocuco.Application.Services.OcucoHub.LuxotticaRxoAuditService.ViewModels
{
    public class RxoAuditSummary
    {
        public int RxoCheckFrameTotalRequests { get; set; }
        public int RxoCheckOrderTotalRequests { get; set; }
        public int RxoSendOrderTotalRequests { get; set; }

        public int RxoCheckFrameErrRequests { get; set; }
        public int RxoCheckOrderErrRequests { get; set; }
        public int RxoSendOrderErrRequests { get; set; }
    }
}
