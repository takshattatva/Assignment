using Assignment.BAL.Interface;
using Assignment.DAL.Models;
using Assignment.DAL.ViewModals;
using System.Threading.Tasks;
using Task = Assignment.DAL.Models.Task;

namespace Assignment.BAL.Repository
{
    public class TaskTableRepo : ITaskTable
    {
        private readonly AssignmentContext _context;
        private readonly AssignmentContext _db;


        public TaskTableRepo(AssignmentContext context, AssignmentContext db)
        {
            _context = context;
            _db = db;
        }
        public List<TaskTable> GetTaskTableData()
        {
            var taskList = _context.Tasks.ToList();

            var GetTaskData = taskList.Select(r => new TaskTable()
            {
                Id = r.Id,
                Taskname = r.Taskname,
                Assignee = r.Assignee,
                Notes = r.Notes,
                Duedate = r.Duedate,
                Category = r.Category,
                City = r.City,

            }).ToList();
            return GetTaskData;
        }
        public List<Category> GetCategories()
        {
            var Categories = _context.Categories.ToList();
            return Categories;
        }

        public void SetAddTaskData(AddTask addTask)
        {
            Task t = new Task()
            {
                Categoryid = addTask.categoryId,
                Taskname = addTask.TaskName,
                Assignee = addTask.Assignee,
                Notes = addTask.Notes,
                Duedate = addTask.DueDate,
                City = addTask.City,
                Category = _db.Categories.FirstOrDefault(x => x.Id == addTask.categoryId).Name,
            };
            _context.Tasks.Add(t);
            _context.SaveChanges();
        }

        public EditTask GetEditTaskData(int Id)
        {
            var tasktable = _db.Tasks.FirstOrDefault(x => x.Id == Id);

            EditTask editTask = new EditTask()
            {
                TaskName = tasktable.Taskname,
                Assignee = tasktable.Assignee,
                Notes = tasktable.Notes,
                DueDate = tasktable.Duedate,
                City = tasktable.City,
                categoryId = tasktable.Categoryid,
                Id = tasktable.Id,
            };
            return editTask;
        }

        public void SetEditTaskData(EditTask editTask, int Id)
        {
            var taskdata = _db.Tasks.FirstOrDefault(x => x.Id == Id);

            if (taskdata != null)
            {
                taskdata.Taskname = editTask.TaskName;
                taskdata.Assignee = editTask.Assignee;
                taskdata.Notes = editTask.Notes;
                taskdata.Duedate = editTask.DueDate;
                taskdata.City = editTask.City;
                taskdata.Categoryid = editTask.categoryId;
                taskdata.Category = _db.Categories.FirstOrDefault(x => x.Id == editTask.categoryId).Name;
            }
            _context.SaveChanges();
        }

        public void DeleteTaskData(int Id)
        {
            var taskdata = _db.Tasks.FirstOrDefault(x => x.Id == Id);

            if (taskdata != null)
            {
                _db.Tasks.Remove(taskdata);
                _db.SaveChanges();
            }    
        }
    }
}


