using CanvasRemake.ViewModels;
using CanvasRemake.Services;

namespace CanvasRemake.Views
{
    public partial class AddStudentView : ContentPage
    {
        public AddStudentView()
        {
            InitializeComponent();
            var navigationService = App.ServiceProvider.GetService<INavigationService>();
            BindingContext = new AddStudentViewModel(navigationService);
        }
    }
}