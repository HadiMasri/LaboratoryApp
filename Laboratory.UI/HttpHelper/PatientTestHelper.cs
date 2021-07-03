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
    public class PatientTestHelper
    {
        public static async Task<string> AddOrUpdatePatientTestAsync(Patient_TestViewModel patientTestVM)
        {
            HttpClient  httpClient = new HttpClient();
            Uri uri = new Uri("https://localhost:44333/PatientTest");
            string json = JsonConvert.SerializeObject(patientTestVM);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(uri, content);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                httpResponseMessage.StatusCode.ToString();
            }
            return "success";
        }



        public static async Task<List<Patient_TestViewModel>> GetPatientTestsAsync(int patientId)
        {
            String Url = "https://localhost:44333/";
            var result = new List<Patient_TestViewModel>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("PatientTest?id=" + patientId).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<Patient_TestViewModel>>(responseBody);
            }
            return result;
        }

        public static void DeletePatientTestAsync(int patientTestId)
        {
            String Url = "https://localhost:44333/";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.DeleteAsync("PatientTest?id=" + patientTestId).Result;
        }
    }
}
