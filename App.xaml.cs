using MauiApp1;
namespace ShipDefectApp;

public partial class App : Application
{
	bool DevMode = true;
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		//return new Window(new AppShell());
		if (DevMode)
			return new Window(new FormsView());
        else
        {
			return new Window(new AppShell());
        }
	}
}