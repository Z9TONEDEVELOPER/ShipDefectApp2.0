
namespace MauiApp1;

public partial class MainInfoTabsView : ContentView
{
	public MainInfoTabsView()
	{
		InitializeComponent();
		LoadView(new MainInfoView());
	}
	private void LoadView(View view)
	{
		TabContent.Content = view;
	}
	private void ResetButtons()
	{
		BtnShipInfo.BackgroundColor = Colors.LightGray;
		BtnShipInfo.TextColor = Colors.Black;

		BtnZotInfo.BackgroundColor = Colors.LightGray;
		BtnZotInfo.TextColor = Colors.Black;

		BtnOtherInfo.BackgroundColor = Colors.LightGray;
		BtnOtherInfo.TextColor = Colors.Black;
	}
	private void ShipInfo_Clicked(object sender, EventArgs e)
	{
		ResetButtons();
		BtnShipInfo.BackgroundColor = Color.FromArgb("#2E86DE");
		BtnShipInfo.TextColor = Colors.White;
		LoadView(new MainInfoView());
	}
	private void ZotInfo_Clicked(object sender, EventArgs e)
	{
		ResetButtons();
		BtnZotInfo.BackgroundColor = Color.FromArgb("#2E86DE");
		BtnZotInfo.TextColor = Colors.White;
		LoadView(new ShipZOTView());
	}
	private void OtherInfo_Clicked(object sender, EventArgs e)
    {
        ResetButtons();
        BtnOtherInfo.BackgroundColor = Color.FromArgb("#2E86DE");
        BtnOtherInfo.TextColor = Colors.White;
        LoadView(new OtherInfoView());
    }
}