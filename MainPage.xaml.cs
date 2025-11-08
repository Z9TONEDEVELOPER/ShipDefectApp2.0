using MauiApp1;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		LoadView(new MainWorkspacePage());
	}

	public void LoadView(View view)
	{
		RightContent.Content = view;
	}
	private void OpenForms_Clicked(object sender, EventArgs e)
    {
        LoadView(new FormsView());
    }

    // 👉 Пример подгрузки таблиц (пока просто заглушки)
    private void OpenTable_Clicked(object sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            var tableName = btn.Text;
            LoadView(new Label
            {
                Text = $"{tableName}\n(заглушка таблицы)",
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            });
        }
    }

	private void OpenMainInfo_Clicked(object sender, EventArgs e)
	{
		LoadView(new MainInfoTabsView());
	}
}