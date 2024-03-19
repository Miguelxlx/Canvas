using CanvasRemake.ViewModels;
using CanvasRemake.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CanvasRemake.Views
{
    public partial class LinkStudentsView : ContentPage
    {
        public LinkStudentsView()
        {
            InitializeComponent();
            var navigationService = App.ServiceProvider.GetService<INavigationService>();
            BindingContext = new LinkStudentsViewModel(navigationService);
        }
    }
}