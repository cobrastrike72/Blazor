using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blazor.Day03.Models.DepartmentModels
{
    public class DepartmentViewModel
    {
            public int DeptId { get; set; }

            [StringLength(50)]
            public string DeptName { get; set; }

            [StringLength(100)]
            public string DeptDesc { get; set; }

            [StringLength(50)]
            public string DeptLocation { get; set; }
            public string ManagerName { get; set; }

            public int DepartmentCapcity { get; set; }
    }

}
