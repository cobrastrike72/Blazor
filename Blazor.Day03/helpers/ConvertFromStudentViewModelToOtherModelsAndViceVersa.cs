namespace Blazor.Day03.helpers
{
    public static class ConvertFromStudentViewModelToOtherModelsAndViceVersa
    {
        public static StudentDisplayModel  ConvertFromStudentViewModelToStudentDisplayViewModel(StudentViewModel student)
        {
            return new StudentDisplayModel()
            {
                StId = student.StId,
                StFname = student.StFname,
                StLname = student.StLname,
                StAddress = student.StAddress,
                DepartmentName = student.DepartmentName,
                StAge = student.StAge,
                SuperStudentName = student.SuperStudentName,
            };
        }

        public static StudentEditModel ConvertFromStudentViewModelToStudentEditViewModel(StudentViewModel student)
        {
            return new StudentEditModel()
            {
                StId = student.StId,
                StFname = student.StFname,
                StLname = student.StLname,
                StAddress = student.StAddress,
                SuperStudentId= student.StSuper,
                StAge = student.StAge,
                DeptId = student.DeptId,
            };
        }

    }
}
