namespace CanvasRemake;
using CanvasRemake.Views;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(AddModuleView), typeof(AddModuleView));
		Routing.RegisterRoute(nameof(AddAssignmentView), typeof(AddAssignmentView));
	}

}
