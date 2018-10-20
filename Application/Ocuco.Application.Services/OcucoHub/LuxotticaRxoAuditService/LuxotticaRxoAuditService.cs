using Microsoft.Extensions.Logging;
using Ocuco.Application.Services.OcucoHub.LuxotticaRxoAuditService.ViewModels;
using Ocuco.Domain.Persistence.Repositories.Rxo;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ocuco.Application.Services.OcucoHub.LuxotticaRxoAuditService
{
    public class LuxotticaRxoAuditService : ILuxotticaRxoAuditService
    {
        private readonly ILogger<LuxotticaRxoAuditService> logger;
        private readonly IRxoRepository rxoRepository;

        public LuxotticaRxoAuditService(ILogger<LuxotticaRxoAuditService> logger,
                                        IRxoRepository rxoRepository)
        {
            this.logger = logger;
            this.rxoRepository = rxoRepository;
        }


        ///////////////////////////////////////////////////////
        //
        // Grid data
        //
        ///////////////////////////////////////////////////////
        public IQueryable<RxoAuditGridViewModel> GetAuditDataForGrids()
        {
            var auditData = rxoRepository.GetRxoAuditData();

            var recList = (from at in auditData
                           orderby at.EventDate descending 
                           select new RxoAuditGridViewModel {
                               AuditID = at.Id,
                               DoorNumber = at.DoorNumber,
                               EventName = at.EventName,
                               EventDate = at.EventDate,
                               EventStatus = at.EventStatus
                           });

            return recList;
        }


        ///////////////////////////////////////////////////////
        //
        // Various ViewModels
        //
        ///////////////////////////////////////////////////////
        public IEnumerable<RxoAuditRecordViewModel> GetAuditRecordsViewModelByDoorID(string doorId)
        {
            var auditData = rxoRepository.GetRxoAuditData();

            var recList = (from at in auditData
                           where (at.DoorNumber == doorId.ToString())
                           orderby at.EventDate descending
                           select new RxoAuditRecordViewModel
                           {
                               AuditID = at.Id,
                               DoorNumber = at.DoorNumber,
                               EventName = at.EventName,
                               EventDate = at.EventDate
                           });

            return recList.AsEnumerable();
        }


        public RxoAuditSummary GetRxoAuditSummary()
        {
            var auditData = rxoRepository.GetRxoAuditData();

            var cfTotal = auditData.Where(w => w.EventName == "CheckFrame").Select(r => r.Id).Count();
            var coTotal = auditData.Where(w => w.EventName == "CheckOrder").Select(r => r.Id).Count();
            var soTotal = auditData.Where(w => w.EventName == "SendOrder").Select(r => r.Id).Count();

            var cfErrTotal = auditData.Where(w => w.EventName == "CheckFrame" && w.EventStatus != "0").Select(r => r.Id).Count();
            var coErrTotal = auditData.Where(w => w.EventName == "CheckOrder" && w.EventStatus != "0").Select(r => r.Id).Count();
            var soErrTotal = auditData.Where(w => w.EventName == "SendOrder" && w.EventStatus != "0").Select(r => r.Id).Count();



            var rxoSummary = new RxoAuditSummary();

            rxoSummary.RxoCheckFrameTotalRequests = cfTotal;
            rxoSummary.RxoCheckOrderTotalRequests = coTotal;
            rxoSummary.RxoSendOrderTotalRequests = soTotal;

            rxoSummary.RxoCheckFrameErrRequests = cfErrTotal;
            rxoSummary.RxoCheckOrderErrRequests = coErrTotal;
            rxoSummary.RxoSendOrderErrRequests = soErrTotal;

            return rxoSummary;
        }



        ///////////////////////////////////////////////////////
        //
        // Async
        //
        ///////////////////////////////////////////////////////
        public async Task<RxoAuditRecordViewModel> GetAuditRecordViewModelAsync(int? id)
        {
            var fullRxoAuditRecord = await rxoRepository.GetAuditRecordAsync(id);

            var auditRecordviewModel = new RxoAuditRecordViewModel()
            {
                AuditID = fullRxoAuditRecord.Id,
                DoorNumber = fullRxoAuditRecord.DoorNumber
            };

            return auditRecordviewModel;
        }
    }
}
