using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using InnoLib;
using Newtonsoft.Json;

namespace ProjectRestConsumer
{
    public class RestConsumer
    {

        public List<Project> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = client.GetStringAsync("http://localhost:52257/api/projects").Result;
                List<Project> pList = JsonConvert.DeserializeObject<List<Project>>(content);
                return pList;
            }
        }

        public Project GetOne(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = client.GetStringAsync("http://localhost:52257/api/projects/" + id.ToString()).Result;
                Project restD = JsonConvert.DeserializeObject<Project>(content);
                return restD;
            }
        }

        public bool Post(Project projectObj)
        {
            // Laver body
            String json = JsonConvert.SerializeObject(projectObj);
            StringContent content = new StringContent(json);
            // Her definerer vi at det er en Json vi sender og ikke eksempelvis XML
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (HttpClient client = new HttpClient())
            {
                // sender
                HttpResponseMessage resultMessage = client.PostAsync("http://localhost:52257/api/projects/", content).Result;
                if (resultMessage.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;

            }
        }
    }
}
