using System.Text.Json;
using System.Net.Http;
using CRUDTareas.Entities;
using System.Threading.Tasks;

namespace CRUDTareas.Services
{
    public class TaskServices
    {
        HttpClient client = new HttpClient();
        string url = "http://192.168.0.8:5000/api/tasks";

        //Get task
        public async Task<TaskResult> GetTask(int id)
        {
            try
            {
                var response = await client.GetAsync($"{url}/{id}");
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<TaskResult>(data)!;

                return result;
            }
            catch (System.Exception ex)
            {
                var result = new TaskResult()
                {
                    status = false,
                    message = ex.Message
                };

                return result;
            }
        }

        //Save a new task
        public async Task<TaskResult> CreateTask(TaskEntity payload)
        {
            try
            {
                var data = JsonSerializer.Serialize(payload);
                HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();
                var final = JsonSerializer.Deserialize<TaskResult>(result)!;
                
                return final;
            }
            catch (System.Exception ex)
            {
                var result = new TaskResult()
                {
                    status = false,
                    message = ex.Message,
                };

                return result;
            }
        }
    }
}
