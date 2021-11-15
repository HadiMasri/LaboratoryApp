using Laboratory.Shared.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory.UI.HttpHelper
{
    public class MaterialHelper
    {
        public static async Task<string> AddOrUpdateMaterialAsync(MaterialViewModel MaterialVM)
        {
            HttpClient  httpClient = new HttpClient();
            Uri uri = new Uri("https://localhost:44333/Material");
            string json = JsonConvert.SerializeObject(MaterialVM);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(uri, content);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                httpResponseMessage.StatusCode.ToString();
            }
            return "success";
        }

        public static async Task<List<MaterialViewModel>> GetMaterialsAsync()
        {
            String Url = "https://localhost:44333/";
            var result = new List<MaterialViewModel>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("Material").Result;
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<MaterialViewModel>>(responseBody);
            }
            return result;
        }

        public static async Task<MaterialViewModel> GetOneMaterialAsync(int MaterialId)
        {
            String Url = "https://localhost:44333/";
            var result = new MaterialViewModel();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("Material/" + MaterialId).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<MaterialViewModel>(responseBody);
            }
            return result;
        }
        public static void DeleteMaterialAsync(int MaterialId)
        {
            String Url = "https://localhost:44333/";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.DeleteAsync("Material?id=" + MaterialId).Result;
        }
    }
}
