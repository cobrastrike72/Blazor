using Microsoft.AspNetCore.Components;

namespace Blazor.Day02.Pages;

public partial class CategoriesComponent
{
    [Inject]
    public IService<Category> CategoryService { get; set; } // this is the way of injecting services in blazor cannot be done in constructor only using properties

    IEnumerable<Category> _categories;
    public int SelectedCategoryId { get; set; }
    public string SelectedCategoryName => (SelectedCategoryId == 0 ? "All Categories" : _categories.FirstOrDefault(c => c.Id == SelectedCategoryId).Name);
    protected override void OnInitialized()
    {
        _categories = CategoryService.GetAll();
        base.OnInitialized();
    }

}
