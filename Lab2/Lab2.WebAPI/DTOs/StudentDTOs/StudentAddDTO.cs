using System.ComponentModel.DataAnnotations;

namespace Lab2.WebAPI.DTOs.StudentDTOs
{
    public class StudentAddDTO
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
