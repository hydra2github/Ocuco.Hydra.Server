using Ocuco.DataModel.Hydradb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocuco.DataModel.Hydradb.Repository
{
    public interface ISampleRepository
    {
        IEnumerable<ArtProduct> GetAllArtProducts();
        IEnumerable<ArtProduct> GetProductsByCategory(string category);


        IEnumerable<ArtOrder> GetAllOrders(bool includeItems);
        ArtOrder GetOrderById(int id);


        bool SaveAll();
        void AddEntity(object model);
    }
}
