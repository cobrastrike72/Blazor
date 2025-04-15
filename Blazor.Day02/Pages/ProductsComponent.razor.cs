using Microsoft.AspNetCore.Components;

namespace Blazor.Day02.Pages;

public partial class ProductsComponent
{
    [Parameter] // indicator that property will take its value from the url param or from a parent component
    public int SelectedCategoryIdFromCategoryComponent { get; set; }
    [Parameter]
    public string SelectedCategoryName { get; set; }

    [Inject]
    public IService<Product> ProductSerive { get; set; }

    public IEnumerable<Product> Products { get; set; }

    protected override void OnParametersSet() // like on change in angular 
    {
        if (SelectedCategoryIdFromCategoryComponent == 0){
            Products = ProductSerive.GetAll();
        }
        else{
            Products = ProductSerive.FindAll(p => p.CategoryId == SelectedCategoryIdFromCategoryComponent);
        }

        base.OnParametersSet();
    }
}
