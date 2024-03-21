using CanvasRemake.ViewModels;
using CanvasRemake.Services;

namespace CanvasRemake.Views
{
    public partial class AddCourseView : ContentPage
    {
        public AddCourseView()
        {
            InitializeComponent();
            var navigationService = App.ServiceProvider.GetService<INavigationService>();
            BindingContext = new AddCourseViewModel(navigationService);
        }
    }
}
