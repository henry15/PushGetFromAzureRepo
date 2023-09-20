using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TranslationLibrary.Webjob.Translate
{
    internal class AzureDevop
    {

        public async void GetFilePAT()
        {
            try
            {
                var personalaccesstoken = "";

                using (HttpClient client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(
                            System.Text.ASCIIEncoding.ASCII.GetBytes(
                                string.Format("{0}:{1}", "", personalaccesstoken))));

                    client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    //https://dev.azure.com/msesc/Localization/_apis/git/repositories/b2e7dc89-3069-4a9f-81b6-6231d0ac436b
                    //https://dev.azure.com/msesc/Localization/_apis/build/folders
                    //  "https://dev.azure.com/msesc/_apis/projects/498577cb-09d5-4ff4-8ae4-8b0b26331a8f").Result)
                    // "https://dev.azure.com/msesc/Localization/_apis/git/repositories/b2e7dc89-3069-4a9f-81b6-6231d0ac436b/items?path=/README.md&includeContent=true"

                    string uri = "https://dev.azure.com/msesc/Localization/_apis/git/repositories/b2e7dc89-3069-4a9f-81b6-6231d0ac436b/items?path=/Ignite%202023/en-US/sample.md&includeContent=true";
                    using (HttpResponseMessage response = client.GetAsync(uri).Result)                      
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(responseBody);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        public async void PushFilePAT()
        {
            try
            {

                var uri = $"https://dev.azure.com/msesc/Localization/_apis/git/repositories/b2e7dc89-3069-4a9f-81b6-6231d0ac436b/pushes?api-version=7.1-preview.2";

                var personalaccesstoken = "";


                using (var client = new HttpClient())
                {                    
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                       Convert.ToBase64String(
                           System.Text.ASCIIEncoding.ASCII.GetBytes(
                               string.Format("{0}:{1}", "", personalaccesstoken))));

                    client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    string text = File.ReadAllText(@"C:/Users/v-henryn/Desktop/Projects/TranslationLibrary/TranslationLibrary.Webjob.Translate/Files/Sample.md");
                   

                    var httpContent = new StringContent((text), Encoding.ASCII, "application/json");
                  //  var response = await client.PostAsync(uri, httpContent);

                    using (HttpResponseMessage response = client.PostAsync(uri, httpContent).Result)
                    {
                        
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(responseBody);
                    }

                    //if (!response.IsSuccessStatusCode)
                    //{
                    //    throw new Exception(ApplicationMessages.FailedToAddFilesToRepository);
                    //}
                }
            }
            catch (Exception ex) { }
        }
    }
}
