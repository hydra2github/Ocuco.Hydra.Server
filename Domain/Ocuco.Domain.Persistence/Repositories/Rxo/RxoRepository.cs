using Microsoft.Extensions.Logging;
using Ocuco.DataModel.Hydradb.Context;
using Ocuco.DataModel.Hydradb.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Ocuco.Domain.Persistence.Repositories.Rxo
{
    public class RxoRepository : IRxoRepository
    {
        private readonly HydraContext context;
        private readonly ILogger<RxoRepository> logger;

        public RxoRepository(HydraContext context, ILogger<RxoRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public void AddEntity(object model)
        {
            context.Add(model);
        }      

        public bool SaveAll()
        {
            return context.SaveChanges() > 0;
        }


        public IQueryable<RxoWsAuditing> GetRxoAuditData()
        {
            var RxoAuditData = (from at in context.RxoWsAuditingTable
                                select at);

            return RxoAuditData;
        }



        ///////////////////////////////////
        //
        // Async
        //
        ///////////////////////////////////

        public async Task<RxoWsAuditing> GetAuditRecordAsync(int? id)
        {
            var auditRecord = await context.RxoWsAuditingTable.FindAsync(id);

            return auditRecord;
        }
    }
}
