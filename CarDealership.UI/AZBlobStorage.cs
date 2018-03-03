using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace CarDealership.UI
{
    public static class AZBlobStorage
    {
        private static string uri = @"https://stmyfiles98.blob.core.windows.net/images/";

        public static string Location()
        {
            return uri;
        }
    }
}