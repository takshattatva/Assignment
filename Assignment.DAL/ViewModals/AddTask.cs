using Assignment.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Assignment.DAL.ViewModals
{
    public class AddTask
    {
        public List<Category> Categories { get; set; }

        [Required(ErrorMessage = "Category Is Required")]
        public int? categoryId { get; set; }

        [Required(ErrorMessage = "Task Name is Required")]
        [RegularExpression(@"^([a-zA-Z]+)$", ErrorMessage = "Invalid Task Name")]
        [StringLength(250, ErrorMessage = "Only 250 Characaters are Accepted")]
        public string TaskName { get; set; }

        [Required(ErrorMessage = "Assignee is Required")]
        [RegularExpression(@"^([a-zA-Z]+)$", ErrorMessage = "Invalid Assignee Name")]
        [StringLength(16, ErrorMessage = "Only 16 Characaters are Accepted")]
        public string? Assignee { get; set; }

        [Required(ErrorMessage = "City is Required")]
        [RegularExpression(@"^([a-zA-Z]+)$", ErrorMessage = "Invalid City Name")]
        [StringLength(16, ErrorMessage = "Only 16 Characaters are Accepted")]
        public string? City { get; set; }

        [Required(ErrorMessage = "DueDate is Required")]
        public DateTime DueDate { get; set; }

        public string? Notes { get; set; }
    }
}
