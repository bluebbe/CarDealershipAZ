using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Auth;

namespace CarDealership.Data.EF
{
    public class Storage
    {
        public Storage()
        {
            _client = new CloudBlobClient(_baseUri, new StorageCredentials("stmyfiles98", "zUv1h90Bv9VizzQ/ThGbH+aHrY+vkra9OfidI0412trUtJ/UcwEjGDx/GBHrhVQ78ff1kaPOFKc/ap8vjAwwQQ==")) ;
        }

        public string SavingImage(byte[] fileByte,string fileName)
        {
          //  var id = Guid.NewGuid().ToString();
            var container = _client.GetContainerReference("images");
            var blob = container.GetBlockBlobReference(fileName);
            blob.UploadFromByteArray(fileByte, 0, fileByte.Length);
            return fileName;
        }

        public string UriFor (string imageId)
        {
            var sasPolicy = new SharedAccessBlobPolicy
            {
                Permissions = SharedAccessBlobPermissions.Read,
                SharedAccessStartTime = DateTime.Now.AddMinutes(-15),
                SharedAccessExpiryTime = DateTime.Now.AddMinutes(30)
            };

            var container = _client.GetContainerReference("images");
            var blob = container.GetBlockBlobReference(imageId);
            var sasToken = blob.GetSharedAccessSignature(sasPolicy);
            return new Uri(_baseUri, $"/images/{imageId}{sasToken}" ).AbsoluteUri;
        }

        Uri _baseUri = new Uri("https://stmyfiles98.blob.core.windows.net/");
        CloudBlobClient _client;
    }
}
