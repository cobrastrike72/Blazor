using System.ComponentModel.DataAnnotations;

namespace Blazor.Day03.Models.StudentModels
{
    public class StudentViewModel
    {
        // Common fields
        [Required]
        public int StId { get; set; }

        [Required]
        public string StFname { get; set; }

        [StringLength(10)]
        public string StLname { get; set; }

        [StringLength(100)]
        public string StAddress { get; set; }

        [Range(1, 150, ErrorMessage = "Age must be between 1 and 150")]
        public int? StAge { get; set; }

        // Editing
        [Range(1, int.MaxValue, ErrorMessage = "Please select a Super Student")]
        public int StSuper { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a Department")]
        public int DeptId { get; set; }

        // Display-only fields (optional for UI)
        public string? SuperStudentName { get; set; }
        public string? DepartmentName { get; set; }
    }
}
