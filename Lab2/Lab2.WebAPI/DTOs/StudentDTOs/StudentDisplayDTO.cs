using Lab2.WebAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lab2.WebAPI.DTOs.StudentDTOs
{
    public class StudentDisplayDTO
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
        [JsonIgnore(Condition=JsonIgnoreCondition.WhenWritingNull)]
        public string SuperStudentName { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string DepartmentName { get; set; }

        public int? DeptId { get; set; }

        public int? StSuper { get; set; }


    }
}
