using CanvasRemake.Models;
using CanvasRemake.ViewModels;
using Microsoft.Maui.Controls;

namespace CanvasRemake.Views
{
    public partial class AddAssignmentView : ContentPage
    {
        public AddAssignmentView(Course course)
        {
            InitializeComponent();
            BindingContext = new AddAssignmentViewModel(course);

            MessagingCenter.Subscribe<AddAssignmentViewModel>(this, "SaveCompleted", async (sender) =>
            {
                await MainThread.InvokeOnMainThreadAsync(() => Navigation.PopAsync());
            });
        }
    }


}
