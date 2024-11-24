using LepskyiSystem.Dto.RawDataDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CraneSimulator
{
    public class ApiService
    {
        HttpClient _client = new HttpClient();

        public ApiService(string url)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(url);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void SendData(CraneSensorRawDataDto data)
        {
            JsonContent content = JsonContent.Create(data);
            HttpResponseMessage response = SendRequest($"/api/crane", HttpMethod.Post, content);
        }

        private HttpResponseMessage SendRequest(string path, HttpMethod method, HttpContent content)
        {
            HttpRequestMessage message = new HttpRequestMessage(method, path);
            message.Content = content;

            return SendRequest(message);
        }

        private HttpResponseMessage SendRequest(HttpRequestMessage request)
        {
            HttpResponseMessage response = _client.Send(request);
            string resp = response.Content.ReadAsStringAsync().Result;
            response.EnsureSuccessStatusCode();

            return response;
        }
    }
}
