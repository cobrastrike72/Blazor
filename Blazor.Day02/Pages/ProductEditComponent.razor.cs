using Microsoft.AspNetCore.Components;

namespace Blazor.Day02.Pages
{
    public partial class ProductEditComponent
    {
        [Parameter] // will get from the url
        public int Id { get; set; }
        public Product Product { get; set; }


        [Inject]
        public IService<Product> ProductService { get; set; }

        [Inject] // built in service registered by default no need to register it again in the program file
        public NavigationManager NavigationManager { get; set; }
        protected override void OnInitialized()
        {
            Product = ProductService.GetById(Id);
            base.OnInitialized();
        }

        void Save()
        {
            Console.WriteLine("Saved Successfully");
            NavigationManager.NavigateTo("/categories");
        }
    }
}
