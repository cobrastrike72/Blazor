using System.ComponentModel.DataAnnotations;

namespace Lab2.WebAPI.DTOs.DepartmentDTOs
{
    public class DepartmentEditDTO
    {
        public int DeptId { get; set; }

        [StringLength(50)]
        public string DeptName { get; set; }

        [StringLength(100)]
        public string DeptDesc { get; set; }

        [StringLength(50)]
        public string DeptLocation { get; set; }

        public int? DeptManager { get; set; }
    }
}
