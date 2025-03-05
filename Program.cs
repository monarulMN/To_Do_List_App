using System;
using System.ComponentModel;
using To_Do_List.Service;

namespace To_DO_List
{
    
    class Program
    {
        static TaskService taskService = new TaskService();
        static void Main()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("===== To Do List =====");
                ShowTasks();
                Console.WriteLine("\n Options:");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. Mark Complete");
                Console.WriteLine("3. Delete Task");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");


                switch(Console.ReadLine())
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        CompleteTask();
                        break;
                    case "3":
                        DeleteTask();
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ShowTasks()
        {
            var tasks = taskService.GetTasks();
            if(tasks.Count ==0)
            {
                Console.WriteLine("No task available");
                return;
            }

            foreach (var task in tasks)
                Console.WriteLine(task);
        }

        static void AddTask()
        {
            Console.WriteLine("Enter task title: ");
            string title = Console.ReadLine();

            if(!string.IsNullOrWhiteSpace(title))
            {
                taskService.AddTask(title);
            }
            else
            {
                Console.WriteLine("Task title can't be empty");
            }
            pause();
        }

        static void CompleteTask()
        {
            Console.WriteLine("Enter task id to mark as complete: ");
            if(int.TryParse(Console.ReadLine(), out int id))
            {
                taskService.MarkComplete(id);
            }
            else
            {
                Console.WriteLine("Invalid task id");
            }
            pause();
        }

        static void DeleteTask()
        {
            Console.WriteLine("Enter task id to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                taskService.DeleteTask(id);
            }
            else
            {
                Console.WriteLine("Invalid task id");
            }
            pause();

        }

        static void pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

    }
}