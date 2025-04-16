using Blazor.Day03.Models.DepartmentModels;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Blazor.Day03.Pages
{
    public partial class StudentEditComponent
    {
        [Parameter] // will get from the url
        public int Id { get; set; }
        public StudentViewModel Student { get; set; }
        public List<DepartmentViewModel> Departments { get; set; }

        public List<StudentViewModel> Students { get; set; }
        [Inject]
        public IService<DepartmentViewModel> DepartmentService { get; set; }


        [Inject]
        public IService<StudentViewModel> StudentService { get; set; }

        [Inject] // built in service registered by default no need to register it again in the program file
        public NavigationManager NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Student = await StudentService.GetAsync(Id);

            Departments = await DepartmentService.GetAllAsync();
            Students = await StudentService.GetAllAsync();  
            base.OnInitialized();
        }

         async void Save()
        {
            await StudentService.UpdateAsync(Id, Student);    
            Console.WriteLine("Saved Successfully");
            NavigationManager.NavigateTo("/students");
        }
    }
}
