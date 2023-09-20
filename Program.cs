using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TranslationLibrary.Webjob.Translate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AzureDevop azureDevop = new AzureDevop();
            //azureDevop.GetFilePAT();
            azureDevop.PushFilePAT();
        }
    }
}