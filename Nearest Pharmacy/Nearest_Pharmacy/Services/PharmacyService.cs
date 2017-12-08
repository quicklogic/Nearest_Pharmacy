using Newtonsoft.Json;
using Nearest_Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Nearest_Pharmacy.Models
{
    public class PharmacyService : IPharmacyService
    {
        HttpClient client;
        public PharmacyService()
        {
            client = new HttpClient();
        }

        public async Task<IEnumerable<Product>> GetProduct()
        {
            
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                string result = await client.GetStringAsync("http://pharmacyapiprototype123.azurewebsites.net/api/products");
                return JsonConvert.DeserializeObject<IEnumerable<Product>>(result);
  
        }

     
        public async Task<UserInfo> Add(UserInfo user)
        {
            var response = await client.PostAsync("http://pharmacyapiprototype123.azurewebsites.net/api/user",
                new StringContent(
                    JsonConvert.SerializeObject(user),
                    Encoding.UTF8, "application/json"));


            if (response.StatusCode != HttpStatusCode.OK) 
                return null;
            return user;
        }


        public async Task<User> Login(User user)
        {
            var response = await client.PostAsync("http://pharmacyapiprototype123.azurewebsites.net/api/login",
                new StringContent(
                    JsonConvert.SerializeObject(user),
                    Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;
            else return user;
        }

        public async Task<List<UserInfo>> GetUserInfo(string login)
        {
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            string uri = "http://pharmacyapiprototype123.azurewebsites.net/api/userinfo/"+login;
            string result = await client.GetStringAsync(uri); 
            return JsonConvert.DeserializeObject<List<UserInfo>>(result);
        }

        public async Task<int> GetSync()
        {
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            string result = await client.GetStringAsync("http://pharmacyapiprototype123.azurewebsites.net/api/sync/");
            return JsonConvert.DeserializeObject<int>(result);
        }

    }
}
