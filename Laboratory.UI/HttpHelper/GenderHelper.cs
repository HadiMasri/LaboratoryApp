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
    public class GenderHelper
    {
        public static async Task<List<GenderViewModel>> GetGendersAsync()
        {
            String Url = "https://localhost:44333/";
            var result = new List<GenderViewModel>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("Gender").Result;
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<GenderViewModel>>(responseBody);
            }
            return result;
        }
    }
}
