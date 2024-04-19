using CanvasRemake.ViewModels;
using CanvasRemake.Services;

namespace CanvasRemake.Views
{
    public partial class SearchStudentView : ContentPage
    {
        public SearchStudentView()
        {
            InitializeComponent();
            var navigationService = App.ServiceProvider.GetService<INavigationService>();
            BindingContext = new SearchStudentViewModel(navigationService);
        }
    }
}