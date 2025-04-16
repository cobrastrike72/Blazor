using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lab2.WebAPI.DTOs.DepartmentDTOs
{
    public class DepartmentDisplayDTO
    {
        public int DeptId { get; set; }

        [StringLength(50)]
        public string DeptName { get; set; }

        [StringLength(100)]
        public string DeptDesc { get; set; }

        [StringLength(50)]
        public string DeptLocation { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ManagerName { get; set; }

        public int DepartmentCapcity {  get; set; }
    }
}
