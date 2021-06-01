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
    public class PatientHelper
    {
        public static async Task<string> AddPatientAsync(PatientViewModel patientVM)
        {
            HttpClient  httpClient = new HttpClient();
            Uri uri = new Uri("https://localhost:44333/Patient");
            string json = JsonConvert.SerializeObject(patientVM);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(uri, content);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                httpResponseMessage.StatusCode.ToString();
            }
            return "success";
        }

        public static async Task<List<PatientViewModel>> GetPatientsAsync()
        {
            String Url = "https://localhost:44333/";
            var result = new List<PatientViewModel>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("Patient").Result;
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<PatientViewModel>>(responseBody);
            }
            return result;
        }

        public static void DeletePatientAsync(int patientId)
        {
            String Url = "https://localhost:44333/";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.DeleteAsync("Patient?id=" + patientId).Result;
        }
    }
}
