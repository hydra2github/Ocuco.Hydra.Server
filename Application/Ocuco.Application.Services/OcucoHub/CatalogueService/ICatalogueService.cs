using Ocuco.Application.Services.OcucoHub.CatalogueService.ViewModels;
using Ocuco.DataModel.Catalog.Entities;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Ocuco.Application.Services.OcucoHub.CatalogueService
{
    public interface ICatalogueService
    {
        //
        // Customer
        //
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomersBySubscriptionKey(string SubscriptionKey);
        //Task<IEnumerable<Customer>> GetAllCustomersAsync();

        //
        // Catalogue
        //
        IEnumerable<Catalogue> GetAllCatalogues();
        IEnumerable<Catalogue> GetCataloguesByCustomerId(int customerId);

        //
        // Product
        //
        IEnumerable<Product> GetProductsByCatalogueId(int catalogueId);
        IEnumerable<HubBrand> GetProductsBrandList(int catalogueid);
        ProductViewModel GetProduct(int id);


        void GetProductImageByUPC(string _upc);
        Task<Stream> GetProductImageByUPCAsync(string _upc);
    }
}
