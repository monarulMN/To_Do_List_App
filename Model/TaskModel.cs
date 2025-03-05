using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List.Model
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }


        public override string ToString()
        {
            return $"{Id}.{(IsCompleted ? "[✔]" : "[ ]")}.{Title}";
        }
    }
}
