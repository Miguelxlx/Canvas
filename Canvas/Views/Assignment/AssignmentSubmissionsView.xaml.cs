using CanvasRemake.ViewModels;
using CanvasRemake.Services;

namespace CanvasRemake.Views
{
    [QueryProperty("AssignmentId", "assignmentId")]
    public partial class AssignmentSubmissionsView : ContentPage
    {
        public string AssignmentId { get; set; }

        public AssignmentSubmissionsView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var apiService = App.ServiceProvider.GetService<ApiService>();
            BindingContext = new AssignmentSubmissionsViewModel(AssignmentId, apiService);
        }
    }
}