using Assignment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DAL.ViewModals
{
    public class TaskTableVm
    {
        public List<TaskTable> TaskList { get; set; } // Task Table data (table)

        public List<Category> Categories { get; set; } // Task Table data (table)
    }

    public class TaskTable
    {
        public int Id { get; set; }

        public string Taskname { get; set; }

        public string? Assignee { get; set; }

        public string? Notes { get; set; }

        public DateTime? Duedate { get; set; }

        public string? Category { get; set; }

        public string? City { get; set; }
    }
}
