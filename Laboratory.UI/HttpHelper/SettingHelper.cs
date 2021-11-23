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
    public class SettingHelper
    {
        public static async Task<List<SettingViewModel>> GetSettingsAsync()
        {
            String Url = "https://localhost:44333/";
            var result = new List<SettingViewModel>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("Setting").Result;
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<SettingViewModel>>(responseBody);
            }
            return result;
        }

        public static async Task<string> AddOrUpdateSettingAsync(SettingViewModel SettingtVM)
        {
            HttpClient httpClient = new HttpClient();
            Uri uri = new Uri("https://localhost:44333/Setting");
            string json = JsonConvert.SerializeObject(SettingtVM);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(uri, content);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                httpResponseMessage.StatusCode.ToString();
            }
            return "success";
        }
        public static void DeleteSettingAsync(int SettingId)
        {
            String Url = "https://localhost:44333/";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.DeleteAsync("Setting?id=" + SettingId).Result;
        }
    }
}
