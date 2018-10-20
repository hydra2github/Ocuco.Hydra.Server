using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Ocuco.Application.Services.OcucoHub.CatalogueService.ViewModels;
using Ocuco.DataModel.Catalog.Entities;
using Ocuco.Domain.Persistence.Repositories.Catalog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Ocuco.Application.Services.OcucoHub.CatalogueService
{
    public class CatalogueService : ICatalogueService
    {
        private readonly ILogger<CatalogueService> logger;
        private readonly ICatalogueRepository repository;

        private CloudStorageAccount storageAccount;
        private CloudBlobClient blobClient;
        private CloudBlobContainer blobContainer;

        public CatalogueService(ILogger<CatalogueService> logger,
                                ICatalogueRepository repository)
        {
            this.logger = logger;
            this.repository = repository;
        }



        //
        // Customer
        //
        public IEnumerable<Customer> GetAllCustomers()
        {
            return repository.GetAllCustomers();
        }
        public Customer GetCustomersBySubscriptionKey(string subscriptionKey)
        {
            return repository.GetCustomerBySubscriptionKey(subscriptionKey);
        }
        //public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        //{
        //    return await repository.GetAllCustomersAsync();
        //}


        //
        // Catalogue
        //
        public IEnumerable<Catalogue> GetAllCatalogues()
        {
            return repository.GetAllCatalogues();
        }
        public IEnumerable<Catalogue> GetCataloguesByCustomerId(int customerId)
        {
            return repository.GetAllCataloguesWithSubscriptions(customerId);
        }

        //
        // Product
        //
        public IEnumerable<Product> GetProductsByCatalogueId(int catalogueId)
        {
            return repository.GetAllProductsByCatalogueId(catalogueId);
        }

        public IEnumerable<HubBrand> GetProductsBrandList(int catalogueId)
        {
            return repository.GetAllBrandsInACatalogue(catalogueId);
        }

        public ProductViewModel GetProduct(int id)
        {
            // Data
            var fullProduct = repository.GetProduct(id);

            var prodVM = new ProductViewModel()
            {
                Id = fullProduct.Id,
                CatalogueId = fullProduct.CatalogueId,
                Upc = fullProduct.Upc,
                Skucode = fullProduct.Skucode,
                ArticleName = fullProduct.ArticleName
            };

            AzureSetupBlobNavigation();

            prodVM.AzureImage = AzureRetrieveInfo(prodVM.Upc);

            return prodVM;
        }


        public void GetProductImageByUPC(string _upc)
        {
            // Data
            var fullProduct = repository.GetProductByUPC(_upc);

            //AzureSetupBlobNavigation();

        }


        public async Task<Stream> GetProductImageByUPCAsync(string _upc)
        {
            //Image aa = new Image();
            // Data
            //    var fullProduct = repository.GetProductByUPC(_upc);

            AzureSetupBlobNavigation();

            var aa = await AzureRetrieveImageAsync(_upc);

            return aa;
        }






        //
        //
        // PRIVATE
        //
        //
        private void AzureSetupBlobNavigation()
        {
            storageAccount = new CloudStorageAccount(
                            new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
                                "sqlhydrasa",
                                "I/Q9dYXqo5ZbzS6gX/1ul35oZBrEjWFCK2aTIWISWgsDPluNphuyqjlZ/kvH6E4qQNNIP6d6Y/fV/bhuEuf8Kw=="), true);

            // Create a blob client.
            blobClient = storageAccount.CreateCloudBlobClient();

            // Get a reference to a container named "mycontainer."
            blobContainer = blobClient.GetContainerReference("hydraimages");
        }

        private string AzureRetrieveInfo(string upc)
        {
            //string filetofind = upc + ".png";
            string filetofind = upc + ".jpg";

            var blob = blobContainer.GetBlockBlobReference(filetofind);

            string blobUrl = blob.Uri.AbsoluteUri;

            if (!AzureFileExists(blobUrl))
                blobUrl = "assets/application/ImagePlaceholder.png";

            return blobUrl;
        }

        private static bool AzureFileExists(string _url)
        {
            //get image from stream and upload
            using (var client = new HttpClient())
            {
                //using (var stream = client.GetStreamAsync(_url).GetAwaiter().GetResult())
                //using (var stream = client.GetStreamAsync(_url).GetAwaiter().GetResult())
                //{
                //    if (stream != null)
                //    {
                //        return true;
                //    }
                //}
                var response = client.GetAsync(_url).Result;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                client.Dispose();
            }
            return false;
        }


        private async Task<Stream> AzureRetrieveImageAsync(string _upc)
        {
            string filetofind = _upc + ".jpg";

            var cloudBlockBlob = blobContainer.GetBlockBlobReference(filetofind);

            var cloudBlob = blobContainer.GetBlobReference(filetofind);

            var image = await cloudBlob.OpenReadAsync();

            return image;

            //return File(image, "image/jpeg");
            //    MemoryStream memstream = new MemoryStream();

            //    await blob.DownloadToStreamAsync(memstream);

            //    return memstream;
        }
    }
}
