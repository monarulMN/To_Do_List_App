using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Do_List.Data;
using To_Do_List.Model;

namespace To_Do_List.Service
{
    public class TaskService
    {
        private readonly TaskRepository _repository;
        private readonly List<TaskModel> _tasks;
        
        public TaskService()
        {
            _repository = new TaskRepository();
            _tasks = _repository.LoadTasks();
        }

        public List<TaskModel> GetTasks() => _tasks;

        public void AddTask(string title)
        {
            int newId = _tasks.Count > 0 ? _tasks[^1].Id + 1 : 1;
            _tasks.Add(new TaskModel { Id = newId, Title = title, IsCompleted = false });
            _repository.SaveTasks(_tasks);
        }

        public void MarkComplete(int id)
        {
            var task = _tasks.Find(t => t.Id == id);
            if(task != null)
            {
                task.IsCompleted = true;
                _repository.SaveTasks(_tasks);
            }
            else
            {
                Console.WriteLine("Task not found");
            }
        }

        public void DeleteTask(int id)
        {
            _tasks.RemoveAll(t => t.Id == id);
            _repository.SaveTasks(_tasks);  
        }

    }
}
