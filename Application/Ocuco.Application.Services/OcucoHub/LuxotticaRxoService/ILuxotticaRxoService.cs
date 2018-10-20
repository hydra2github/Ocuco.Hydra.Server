using Ocuco.Application.Services.OcucoHub.LuxotticaRxoService.Dtos;

namespace Ocuco.Application.Services.OcucoHub.LuxotticaRxoService
{
    public interface ILuxotticaRxoService
    {
        RxoBaseResponseEntity CallCheckFrame(RxoCheckFrameRequest modelCheckFrame);
        RxoBaseResponseEntity CallCheckOrder(RxoCheckOrderRequest modelCheckOrder);
        RxoBaseResponseEntity CallSendOrder(RxoSendOrderRequest modelSendOrder);
    }
}
