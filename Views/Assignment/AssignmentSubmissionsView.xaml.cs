using CanvasRemake.ViewModels;
using CanvasRemake.Models;

using Microsoft.Maui.Controls;

namespace CanvasRemake.Views
{
    [QueryProperty("Assignment", "assignment")]
    public partial class AssignmentSubmissionsView : ContentPage
    {
        public Assignment Assignment { get; set; }

        public AssignmentSubmissionsView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new AssignmentSubmissionsViewModel(Assignment);
        }
    }
}