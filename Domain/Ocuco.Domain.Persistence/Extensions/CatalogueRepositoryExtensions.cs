using Ocuco.DataModel.Catalog.Entities;
using Ocuco.Domain.Persistence.Repositories.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocuco.Domain.Persistence.Repositories.Catalog
{
    public static class CatalogueRepositoryExtensions
    {
        public static Customer GetCustomerBySubscriptionKey(this ICatalogueRepository _CatalogueRepository, string _subscriptionKey)
        {
            return _CatalogueRepository.GetAllCustomers().Where(sk => sk.SubscriptionKey == _subscriptionKey).FirstOrDefault();
        }

        //public static IEnumerable<Catalogue> GetCataloguesByCustomerId(this ICatalogueRepository _CatalogueRepository, int _customerId)
        //{
        //    return _CatalogueRepository.GetAllCataloguesWithSubscriptions().Where(c => c.CatalogueSubscription.CatalogueSubscription. == _subscriptionKey).FirstOrDefault();
        //}

        //public static Product Get

    }
}
