namespace MauiApp1;

public partial class MainWorkspacePage : ContentView
{
    private List<TreeItem> _inputTreeItems;
    private List<TreeItem> _reportTreeItems;

    public MainWorkspacePage()
    {
        InitializeComponent();
        LoadInputTree();
        LoadContent(new MainInfoTabsView());
    }

    private void LoadInputTree()
    {
        _inputTreeItems = new List<TreeItem>
        {
            new TreeItem { Title = "Основная информация", Type = "main", FontStyle = FontAttributes.Bold, Margin = new Thickness(0, 5, 0, 0) },
            new TreeItem { Title = "   Таблица 3.5.3", Type = "table" },
            new TreeItem { Title = "   Таблица 2.4.1", Type = "table" },
            new TreeItem { Title = "   Таблица 3.5.5", Type = "table" },

            new TreeItem { Title = "Формы", Type = "forms", FontStyle = FontAttributes.Bold, Margin = new Thickness(0, 8, 0, 0) }
        };

        TreeViewList.ItemsSource = _inputTreeItems;
    }

    private void LoadReportTree()
    {
        _reportTreeItems = new List<TreeItem>
        {
            new TreeItem { Title = "Титульный лист", Type = "report" },
            new TreeItem { Title = "Заключение", Type = "report" },
            new TreeItem { Title = "Приложения", Type = "report" }
        };

        TreeViewList.ItemsSource = _reportTreeItems;
    }

    private void OnInputClicked(object sender, EventArgs e)
    {
        ResetTabs();
        BtnInput.BackgroundColor = Color.FromArgb("#2E86DE");
        BtnInput.TextColor = Colors.White;
        LoadInputTree();
        LoadContent(new MainInfoTabsView());
    }

    private void OnReportClicked(object sender, EventArgs e)
    {
        ResetTabs();
        BtnReport.BackgroundColor = Color.FromArgb("#2E86DE");
        BtnReport.TextColor = Colors.White;
        LoadReportTree();
        LoadContent(new Label
        {
            Text = "Создание отчёта (заглушка)",
            FontSize = 20,
            HorizontalOptions = LayoutOptions.Center
        });
    }

    private void ResetTabs()
    {
        BtnInput.BackgroundColor = Colors.LightGray;
        BtnInput.TextColor = Colors.Black;
        BtnReport.BackgroundColor = Colors.LightGray;
        BtnReport.TextColor = Colors.Black;
    }

    private void OnTreeItemSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not TreeItem selected)
            return;

        switch (selected.Type)
        {
            case "main":
                LoadContent(new MainInfoTabsView());
                break;

            case "forms":
                LoadContent(new Label { Text = "Формы (заглушка)", FontSize = 20, HorizontalOptions = LayoutOptions.Center });
                break;

            case "table":
                LoadContent(new Label { Text = $"{selected.Title} (таблица — заглушка)", FontSize = 18, HorizontalOptions = LayoutOptions.Center });
                break;

            case "report":
                LoadContent(new Label { Text = $"{selected.Title} (раздел отчёта)", FontSize = 18, HorizontalOptions = LayoutOptions.Center });
                break;
        }
    }

    private void LoadContent(View view)
    {
        ContentArea.Content = view;
    }
}

public class TreeItem
{
    public string Title { get; set; }
    public string Type { get; set; }
    public FontAttributes FontStyle { get; set; } = FontAttributes.None;
    public Thickness Margin { get; set; } = new Thickness(10, 0);
}