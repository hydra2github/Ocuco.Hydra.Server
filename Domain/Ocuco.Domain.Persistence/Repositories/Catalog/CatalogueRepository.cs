using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ocuco.DataModel.Catalog.Context;
using Ocuco.DataModel.Catalog.Entities;
using Ocuco.DataModel.Hydradb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ocuco.Domain.Persistence.Repositories.Catalog
{
    public class CatalogueRepository : ICatalogueRepository
    {
        private readonly hydradbcatalogContext context;
        private readonly ILogger<CatalogueRepository> logger;

        public CatalogueRepository(hydradbcatalogContext context, ILogger<CatalogueRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }



        //
        // base actions
        //

        public void AddEntity(object model)
        {
            context.Add(model);
        }

        public bool SaveAll()
        {
            return context.SaveChanges() > 0;
        }



        ///////////////////////////////////////////////////////////
        //
        // Catalogue data 
        //
        ///////////////////////////////////////////////////////////

        public IEnumerable<Customer> GetAllCustomers()
        {
            return context.Customer.ToList();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            try
            {
                logger.LogInformation("GetAllCustomersAsync call");

                return await context.Customer
                             .OrderBy(p => p.Id)
                             .ToListAsync();

            }
            catch (Exception ex)
            {
                logger.LogError($"Error: {ex}");
                return null;
            }
        }


        public IEnumerable<Catalogue> GetAllCatalogues()
        {
            return context.Catalogue
                          .Include(o => o.Manufacturer)
                          .ToList();
        }

        public IEnumerable<Catalogue> GetAllCataloguesWithSubscriptions(int customerId)
        {
            return context.Catalogue
                          .Include(o => o.CatalogueSubscription)
                          .Where(c => c.CatalogueSubscription.Any(cst => cst.CustomerId == customerId))
                          .ToList();
        }


        //
        // Product data
        //
        public IEnumerable<Product> GetAllProductsByCatalogueId(int catalogueId)
        {
            return context.Product
                          .Where(c => c.CatalogueId == catalogueId)
                          .ToList();
        }


        public IEnumerable<HubBrand> GetAllBrandsInACatalogue(int catalogueId)
        {
            var subselect = (from prd in context.Product
                             where prd.CatalogueId == catalogueId
                             group prd.HubBrandId by prd.HubBrandId into hbGroup
                             select hbGroup.Key);

            var custContact = (from brand in context.HubBrand
                               where subselect.Contains(brand.Id)
                               select brand
                               );

            return custContact;
        }

        public Product GetProduct(int id)
        {
            return context.Product.Find(id);
        }

        public Product GetProductByUPC(string _upc)
        {
            return context.Product
                           .Where(p => p.Upc == _upc)
                           .FirstOrDefault();
        }




















        //public IQueryable<RxoWsAuditing> GetRxoAuditData()
        //{
        //    var RxoAuditData = (from at in context.RxoWsAuditingTable
        //                        select at);

        //    return RxoAuditData;
        //}

        //public async Task<RxoWsAuditing> GetAuditRecordAsync(int? id)
        //{
        //    var auditRecord = await context.RxoWsAuditingTable.FindAsync(id);

        //    return auditRecord;
        //}
    }
}
