using MauiApp1;
namespace ShipDefectApp;

public partial class App : Application
{
	bool DevMode = false;
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		//return new Window(new AppShell());
		if (DevMode)
			return new Window();
        else
        {
			return new Window(new AppShell());
        }
	}
}