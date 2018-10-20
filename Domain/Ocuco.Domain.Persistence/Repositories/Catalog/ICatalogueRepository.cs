using Ocuco.DataModel.Catalog.Entities;
using Ocuco.DataModel.Hydradb.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ocuco.Domain.Persistence.Repositories.Catalog
{
    public interface ICatalogueRepository
    {
        //
        // base actions
        //
        void AddEntity(object model);
        bool SaveAll();

        /////////////////////////////////////////

        //        
        // Customer data
        //
        IEnumerable<Customer> GetAllCustomers();
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        
        //
        // Catalogue data 
        //        
        IEnumerable<Catalogue> GetAllCatalogues();
        IEnumerable<Catalogue> GetAllCataloguesWithSubscriptions(int customerId);

        //
        // Product data
        //
        IEnumerable<Product> GetAllProductsByCatalogueId(int catalogueId);
        IEnumerable<HubBrand> GetAllBrandsInACatalogue(int catalogueId);
        Product GetProduct(int id);

        Product GetProductByUPC(string _upc);


        //IQueryable<RxoWsAuditing> GetRxoAuditData();
        //Task<RxoWsAuditing> GetAuditRecordAsync(int ?id);
    }
}