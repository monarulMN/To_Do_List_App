using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using To_Do_List.Model;

namespace To_Do_List.Data
{
    public class TaskRepository
    {
        private readonly string filePath = "tasks.txt";

        public List<TaskModel> LoadTasks()
        {
            if(!File.Exists(filePath)) return new List<TaskModel>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<TaskModel>>(json) ?? new List<TaskModel>();
        }

        public void SaveTasks(List<TaskModel> tasks)
        {
            string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true});
            File.WriteAllText(filePath, json);
        }
    }
}
