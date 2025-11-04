using MauiApp1;
namespace ShipDefectApp;

public partial class MainPage : ContentPage
{


	public MainPage()
	{
		InitializeComponent();
		LoadView(new MainInfoView());
	}
	public void LoadView(View view)
	{
		RightContent.Content = view;
	}
	private void OpenMainInfo_Clicked(object sender, EventArgs e)
	{
		LoadView(new MainInfoView());
	}

	
}
