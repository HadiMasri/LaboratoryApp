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
    public class TitleHelper
    {
        public static async Task<List<TitleViewModel>> GetTitlesAsync()
        {
            String Url = "https://localhost:44333/";
            var result = new List<TitleViewModel>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("Title").Result;
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<TitleViewModel>>(responseBody);
            }
            return result;
        }
    }
}
