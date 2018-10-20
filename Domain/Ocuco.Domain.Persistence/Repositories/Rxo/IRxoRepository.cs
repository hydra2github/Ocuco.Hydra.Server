using Ocuco.DataModel.Hydradb.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ocuco.Domain.Persistence.Repositories.Rxo
{
    public interface IRxoRepository
    {
        //
        // base actions
        //

        void AddEntity(object model);
        bool SaveAll();


        //
        // Rxo Audit data 
        //

        IQueryable<RxoWsAuditing> GetRxoAuditData();

        Task<RxoWsAuditing> GetAuditRecordAsync(int ?id);
    }
}