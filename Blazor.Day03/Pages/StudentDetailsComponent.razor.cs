using Microsoft.AspNetCore.Components;

namespace Blazor.Day03.Pages
{
    public partial class StudentDetailsComponent
    {
        [Parameter] // to get from the url
        public int Id { get; set; }
        public StudentDisplayModel SelectedStudent { get; set; }

        [Inject]
        public IService<StudentViewModel> StudentService { get; set; }


        protected override async Task OnInitializedAsync()
        {
            var std = await StudentService.GetAsync(Id);
            SelectedStudent = ConvertFromStudentViewModelToOtherModelsAndViceVersa.ConvertFromStudentViewModelToStudentDisplayViewModel(std);
            base.OnInitializedAsync();
        }
    }
}
