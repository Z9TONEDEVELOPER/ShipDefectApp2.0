namespace MauiApp1;

public partial class CreatingReportView : ContentView
{
	public CreatingReportView()
	{
		InitializeComponent();
	}
	private void LoadView(View view)
    {
        ReportContent.Content = view;
    }

    private void OpenTitle_Clicked(object sender, EventArgs e)
    {
        LoadView(new TitlePageView());
    }

    private void OpenForm_Clicked(object sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            
        }
    }
}