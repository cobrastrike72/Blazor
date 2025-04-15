using Microsoft.AspNetCore.Components;

namespace Blazor.Day02.Pages;

public partial class ProductDetailsComponent
{
    [Parameter]
    public int Id { get; set; }
    [Inject]
    public IService<Product> ProductService { get; set; }

    public Product Product { get; set; }


    protected override void OnInitialized()
    {
        Product = ProductService.GetById(Id);
        base.OnInitialized();
    }
}
