using Assignment.BAL.Interface;
using Assignment.DAL.Models;
using Assignment.DAL.ViewModals;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    public class TaskController : Controller
    {
        private readonly AssignmentContext _context;
        private readonly ITaskTable _task;

        public TaskController(AssignmentContext context, ITaskTable task)
        {
            _context = context;
            _task = task;
        }
        /// <summary>
        /// Fetch Task Table
        /// </summary>
        /// <returns></returns>
        public IActionResult TaskTable()
        {
            TaskTableVm taskTableVm = new TaskTableVm();
            taskTableVm.TaskList = _task.GetTaskTableData();

            return View(taskTableVm);
        }
        
        /// <summary>
        /// Fetch Create Task Modal
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateTask()
        {
            AddTask addTask = new AddTask();
            addTask.Categories = _task.GetCategories();

            return PartialView("_Add_Task", addTask);
        }
        /// <summary>
        /// Update Create Task Modal
        /// </summary>
        /// <param name="addTask"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateTaskPost(AddTask addTask)
        {
            _task.SetAddTaskData(addTask);
            return RedirectToAction("TaskTable");
        }

        /// <summary>
        /// Fetch Edit Task Modal
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IActionResult EditTask(int Id)
        {
            EditTask editTask = _task.GetEditTaskData(Id);
            editTask.Categories = _task.GetCategories();

            return PartialView("_Edit_Task", editTask);
        }

        /// <summary>
        /// Update Edit Task Modal
        /// </summary>
        /// <param name="editTask"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EditTaskPost(EditTask editTask, int Id)
        {
            _task.SetEditTaskData(editTask,Id);
            return RedirectToAction("TaskTable");
        }

        /// <summary>
        /// Update Delete Task
        /// </summary>
        /// <param name="editTask"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteTask(int Id)
        {
            _task.DeleteTaskData(Id);
            return RedirectToAction("TaskTable");
        }

    }
}
