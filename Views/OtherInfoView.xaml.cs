using System.Collections.ObjectModel;
using MauiApp1.Models;
using MauiApp1.Views.Popups;
using CommunityToolkit.Maui.Extensions;
using Microsoft.Extensions.Logging;
using UIKit;
namespace MauiApp1;

public partial class OtherInfoView : ContentView
{
    private ObservableCollection<CommissionMember> Members = new();
	private readonly ILogger<OtherInfoView> _logger;

    public OtherInfoView()
    {
		InitializeComponent();
		_logger = ShipDefectApp.MauiProgram.CreateMauiApp().Services.GetService<ILogger<OtherInfoView>>();

        // Пример записи
        _logger?.LogInformation("OtherInfoView инициализирован");

        // инициализация таблицы комиссии
        CommissionList.ItemsSource = Members;

        // по умолчанию — прибор 1
        LoadDevice(1);
    }

    // --- вкладки приборов ---
    private void ResetButtons()
    {
        BtnDevice1.BackgroundColor = Colors.LightGray;
        BtnDevice1.TextColor = Colors.Black;

        BtnDevice2.BackgroundColor = Colors.LightGray;
        BtnDevice2.TextColor = Colors.Black;

        BtnDevice3.BackgroundColor = Colors.LightGray;
        BtnDevice3.TextColor = Colors.Black;
    }

    private void Device1_Clicked(object sender, EventArgs e)
    {
        ResetButtons();
        BtnDevice1.BackgroundColor = Color.FromArgb("#2E86DE");
        BtnDevice1.TextColor = Colors.White;
        LoadDevice(1);
    }

    private void Device2_Clicked(object sender, EventArgs e)
    {
        ResetButtons();
        BtnDevice2.BackgroundColor = Color.FromArgb("#2E86DE");
        BtnDevice2.TextColor = Colors.White;
        LoadDevice(2);
    }

    private void Device3_Clicked(object sender, EventArgs e)
    {
        ResetButtons();
        BtnDevice3.BackgroundColor = Color.FromArgb("#2E86DE");
        BtnDevice3.TextColor = Colors.White;
        LoadDevice(3);
    }

    private void LoadDevice(int num)
    {
        var layout = new VerticalStackLayout { Padding = 10, Spacing = 8 };

        layout.Children.Add(new Label
        {
            Text = $"Прибор {num}",
            FontAttributes = FontAttributes.Bold,
            FontSize = 16
        });

        layout.Children.Add(DeviceField("Наименование прибора:"));
        layout.Children.Add(DeviceField("Серийный номер:"));
        layout.Children.Add(DeviceField("Название изготовителя:"));
        layout.Children.Add(DeviceField("Точность измерений:"));
        layout.Children.Add(DeviceField("Свидетельство о проверке №:"));

        var dateRow = new HorizontalStackLayout { Spacing = 8 };
        dateRow.Children.Add(new Label { Text = "Действителен до:", VerticalOptions = LayoutOptions.Center });
        dateRow.Children.Add(new DatePicker());
        layout.Children.Add(dateRow);

        DeviceContent.Content = layout;
    }

    private View DeviceField(string label)
    {
        var row = new HorizontalStackLayout { Spacing = 8 };
        row.Children.Add(new Label { Text = label, VerticalOptions = LayoutOptions.Center });
        row.Children.Add(new Entry { WidthRequest = 300 });
        return row;
    }

    // --- Комиссия ---

    private void AddMember_Clicked(object sender, EventArgs e)
    {
        Members.Add(new CommissionMember());
    }

    private void RemoveMember_Clicked(object sender, EventArgs e)
    {
        if (CommissionList.SelectedItem is CommissionMember member)
            Members.Remove(member);
    }

    private async Task<string?> PickImageAsync()
	{
		try
		{
			var result = await FilePicker.PickAsync(new PickOptions
			{
				PickerTitle = "Выберите изображение",
				FileTypes = FilePickerFileType.Images
			});

			if (result == null)
			{
				_logger?.LogWarning("❌ Результат выбора файла — null");
				return null;
			}

			_logger?.LogInformation($"📄 Выбран файл: {result.FullPath}");

			// Проверим, существует ли файл по пути
			if (!File.Exists(result.FullPath))
			{
				_logger?.LogWarning($"⚠️ Файл не найден по пути: {result.FullPath}");
				return null;
			}

			return result.FullPath;
		}
		catch (Exception ex)
		{
			_logger?.LogError(ex, "Ошибка при выборе изображения");
			return null;
		}
	}

    private async void OnSelectSignatureClicked(object sender, EventArgs e)
	{
		if (sender is Button btn && btn.CommandParameter is CommissionMember member)
		{
			var path = await PickImageAsync();
			if (!string.IsNullOrEmpty(path))
			{
				member.SignatureImagePath = path;
				_logger?.LogInformation($"✅ Файл подписи выбран: {path}");
			}
			else
			{
				_logger?.LogWarning("⚠️ Пользователь отменил выбор подписи");
			}
		}
	}

	private async void OnSelectStampClicked(object sender, EventArgs e)
	{
		if (sender is Button btn && btn.CommandParameter is CommissionMember member)
		{
			var path = await PickImageAsync();
			if (!string.IsNullOrEmpty(path))
			{
				member.StampImagePath = path;
			}
		}
	}
}