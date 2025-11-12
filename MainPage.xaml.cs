using MauiApp1.Views;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        LoadContent(new DataEntryView()); // по умолчанию открываем ввод данных
    }

    private void LoadContent(View view)
    {
        MainContent.Content = view;
    }

    private void OpenDataEntry_Clicked(object sender, EventArgs e)
    {
        LoadContent(new DataEntryView());
    }

    private void OpenReport_Clicked(object sender, EventArgs e)
    {
        LoadContent(new CreatingReportView());
    }
}