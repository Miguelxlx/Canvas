using CanvasRemake.ViewModels;
using CanvasRemake.Services;

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