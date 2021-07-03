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
    public class TestRangeHelper
    {
        public static async Task<List<TestRangeViewModel>> GetTestRangesAsync(int testId)
        {
            String Url = "https://localhost:44333/";
            var result = new List<TestRangeViewModel>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("TestRange?testId=" + testId).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<TestRangeViewModel>>(responseBody);
            }
            return result;
        }

        public static async Task<TestRangeViewModel> GetOneTestRangeAsync(int testId)
        {
            String Url = "https://localhost:44333/";
            var result = new TestRangeViewModel();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("TestRange?id=" + testId).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<TestRangeViewModel>(responseBody);
            }
            return result;
        }

        public static async Task<string> AddOrUpdateTestAsync(TestRangeViewModel testRangetVM)
        {
            HttpClient httpClient = new HttpClient();
            Uri uri = new Uri("https://localhost:44333/TestRange");
            string json = JsonConvert.SerializeObject(testRangetVM);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(uri, content);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                httpResponseMessage.StatusCode.ToString();
            }
            return "success";
        }
        public static void DeleteTestAsync(int testRangeId)
        {
            String Url = "https://localhost:44333/";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.DeleteAsync("TestRange?id=" + testRangeId).Result;
        }
    }
}
