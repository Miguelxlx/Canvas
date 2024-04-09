using CanvasRemake.ViewModels;
using CanvasRemake.Services;

namespace CanvasRemake.Views
{
    public partial class SearchCourseView : ContentPage
    {
        public SearchCourseView()
        {
            InitializeComponent();
            var navigationService = App.ServiceProvider.GetService<INavigationService>();
            BindingContext = new SearchCourseViewModel(navigationService);
        }
    }
}