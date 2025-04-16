using System.ComponentModel.DataAnnotations;

namespace Blazor.Day03.Models.StudentModels
{
    public class StudentEditModel
    {
        [Required]
        public int StId { get; set; }
        [Required]
        public string StFname { get; set; }

        [StringLength(10)]
        public string StLname { get; set; }

        [StringLength(100)]
        public string StAddress { get; set; }

        public int? StAge { get; set; }

        public int SuperStudentId { get; set; }

        public int DeptId { get; set; }
    }
}
