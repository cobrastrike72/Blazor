using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blazor.Day03.Models.StudentModels
{
    public class StudentDisplayModel
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
        public string? SuperStudentName { get; set; }
        public string? DepartmentName { get; set; }
    }
}
