using CommunityToolkit.Mvvm.ComponentModel;
using CanvasRemake.Models;

namespace CanvasRemake.ViewModels
{
    public partial class AssignmentSubmissionsViewModel : ObservableObject
    {
        private readonly Assignment _assignment;

        public AssignmentSubmissionsViewModel(Assignment assignment)
        {
            _assignment = assignment;
        }

        public Assignment Assignment => _assignment;
    }
}