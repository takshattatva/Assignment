using Assignment.DAL.Models;
using Assignment.DAL.ViewModals;

namespace Assignment.BAL.Interface
{
    public interface ITaskTable
    {
        List<Category> GetCategories();

        List<TaskTable> GetTaskTableData();

        void SetAddTaskData(AddTask addTask);

        EditTask GetEditTaskData(int Id);

        void SetEditTaskData(EditTask editTask, int Id);

        void DeleteTaskData(int Id);

    }
}