using CrudGUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrudGUI
{
    public class DataAccess
    {

        public async Task<List<dynamic>> GetEntitiesAsync(string path)
        {
            List<dynamic> data;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://challengeapinicholasnew.azurewebsites.net/");

                string product = "";

                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    product = await response.Content.ReadAsStringAsync();
                }
                data = JsonConvert.DeserializeObject<List<dynamic>>(product);

            }
            return data;
        }

        public async Task<bool> PostEntityAsync(string path, dynamic data)
        {
            HttpResponseMessage call;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://challengeapinicholas.azurewebsites.net/");

                var myContent = JsonConvert.SerializeObject(data);

                var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

                call = await client.PostAsync(path, stringContent);
            }

            return call.IsSuccessStatusCode;
        }

        //Update
        public async Task<bool> PutEntityAsync(string path, dynamic data)
        {
            HttpResponseMessage call;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://challengeapinicholas.azurewebsites.net/");

                var myContent = JsonConvert.SerializeObject(data);

                var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

                call = await client.PutAsync(path, stringContent);
            }
            return call.IsSuccessStatusCode;
        }

        //Delete
        public async Task<bool> DeleteEntityAsync(string path)
        {
            HttpResponseMessage call;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://challengeapinicholas.azurewebsites.net/");

                call = await client.DeleteAsync(path);

            }
            return call.IsSuccessStatusCode;
        }
    }
}
