using Ocuco.Application.Services.OcucoHub.LuxotticaRxoAuditService.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ocuco.Application.Services.OcucoHub.LuxotticaRxoAuditService
{
    public interface ILuxotticaRxoAuditService
    {
        ///////////////////////////////////////////////////////
        //
        // Grid data
        //
        ///////////////////////////////////////////////////////
        IQueryable<RxoAuditGridViewModel> GetAuditDataForGrids();



        ///////////////////////////////////////////////////////
        //
        // Various ViewModels
        //
        ///////////////////////////////////////////////////////
        IEnumerable<RxoAuditRecordViewModel> GetAuditRecordsViewModelByDoorID(string doorId);


        RxoAuditSummary GetRxoAuditSummary();



        ///////////////////////////////////////////////////////
        //
        // Async
        //
        ///////////////////////////////////////////////////////
        Task<RxoAuditRecordViewModel> GetAuditRecordViewModelAsync(int? id);
    }
}