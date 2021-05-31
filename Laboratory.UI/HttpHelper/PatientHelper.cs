using Laboratory.Shared.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
    }
}
