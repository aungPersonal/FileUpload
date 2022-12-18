using FileUpload.API.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Consts
{
    public static class Const
    {
        public readonly static string PARAM_APPLICATION = "FileUpload";

        public static string ENVIRONMENT = string.Empty;
        public static string DB_CONNECTION = string.Empty;
        public readonly static string TransactionCSVStatus_Approved = "Approved";
        public readonly static string TransactionCSVStatus_Failed = "Failed";
        public readonly static string TransactionCSVStatus_Finished = "Finished";
        public static void loadConfigData()
        {
            var filePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "Configs\\AppSetting.config");
            var xml = System.Xml.Linq.XElement.Load(filePath);
            var xmlRetriever = new XMLRetriever(xml);
            DB_CONNECTION = xmlRetriever.GetParameter(PARAM_APPLICATION + ".dbConnection");

        }
    }
}
