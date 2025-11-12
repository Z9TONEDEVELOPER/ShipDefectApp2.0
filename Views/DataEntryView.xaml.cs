namespace MauiApp1;

public partial class DataEntryView : ContentView
{
    public DataEntryView()
    {
        InitializeComponent();
    }

    private void OpenMainInfo_Clicked(object sender, EventArgs e)
    {
        RightContent.Content = new MainInfoTabsView();
    }

    private void OpenForms_Clicked(object sender, EventArgs e)
    {
        RightContent.Content = new FormsView();
    }

    private void OpenTable_Clicked(object sender, EventArgs e)
    {
        
    }
}