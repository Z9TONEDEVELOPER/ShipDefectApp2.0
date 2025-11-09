using MauiApp1;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    // 👉 Обработка кнопки "Основная информация"
    private void OpenMainInfo_Clicked(object sender, EventArgs e)
    {
        LoadContent(new MainInfoTabsView());
    }

    // 👉 Пример обработки кнопки "Формы"
    private void OpenForms_Clicked(object sender, EventArgs e)
    {
        LoadContent(new FormsView());
    }

    // 👉 Пример подгрузки таблиц (пока просто заглушки)
    private void OpenTable_Clicked(object sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            var tableName = btn.Text;
            LoadContent(new Label
            {
                Text = $"{tableName}\n(заглушка таблицы)",
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            });
        }
    }

    // 👉 Метод загрузки контента в правую часть
    private void LoadContent(View view)
    {
        RightContent.Content = view;
    }
}