using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data
{
    public class Settings
    {
        private static string _repositoryType;
        private static string _savingFileLocation;

        private static string _connectionString;
        public static string GetRepositoryType()
        {
            if (string.IsNullOrEmpty(_repositoryType))
            {

                _repositoryType = ConfigurationManager.AppSettings["Mode"].ToString();

            }
            return _repositoryType;

        }

        public static string GetSavingFileLocation()
        {

            if (string.IsNullOrEmpty(_savingFileLocation))
                _savingFileLocation = ConfigurationManager.AppSettings["SaveFile"].ToString();

            return _savingFileLocation;
        }


        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_connectionString))
                _connectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;

            return _connectionString;
        }
    }
}
