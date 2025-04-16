using Microsoft.AspNetCore.Components;

namespace Blazor.Day03.Pages;

public partial class StudentComponent
{
    [Inject]
    public IService<StudentViewModel> StudentService { get; set; }
    public List<StudentDisplayModel> Students { get; set; }


    protected override async Task OnInitializedAsync()
    {
        var stds =  await StudentService.GetAllAsync();
        // select only the properties i need from the studentViewModel that includes most of the properties
        // it needs to be implemented using static class and method (in order not to repeat the code)
        Students = new List<StudentDisplayModel>();
        foreach (var student in stds)
        {
            Students.Add(ConvertFromStudentViewModelToOtherModelsAndViceVersa.ConvertFromStudentViewModelToStudentDisplayViewModel(student));
        }
        base.OnInitializedAsync();
    }
}
