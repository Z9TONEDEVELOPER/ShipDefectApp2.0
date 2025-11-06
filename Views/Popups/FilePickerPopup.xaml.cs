using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Extensions; // для ClosePopupAsync/ShowPopupAsync
using Microsoft.Maui.Storage;
using System.IO;
using System.Threading;

namespace MauiApp1.Views.Popups;

public partial class FilePickerPopup : Popup
{
    public static string? SelectedFilePath { get; private set; }

    public FilePickerPopup()
    {
		InitializeComponent();
		SelectedFilePath = null;
    }

    private async void PickFileClicked(object sender, EventArgs e)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Выберите изображение",
                FileTypes = FilePickerFileType.Images
            });

            if (result == null) return;

            var fileName = Path.GetFileName(result.FileName);
            var localPath = Path.Combine(FileSystem.CacheDirectory, fileName);

            using var source = await result.OpenReadAsync();
            using var dest = File.Create(localPath);
            await source.CopyToAsync(dest);

            SelectedFilePath = localPath;
            PreviewImage.Source = ImageSource.FromFile(localPath);
            PreviewImage.IsVisible = true;
        }
        catch (Exception ex)
        {
            await Application.Current!.MainPage!.DisplayAlert("Ошибка", ex.Message, "OK");
        }
    }

    private async void OkClicked(object sender, EventArgs e)
    {
        await Shell.Current.ClosePopupAsync(CancellationToken.None);
    }

    private async void CancelClicked(object sender, EventArgs e)
    {
        SelectedFilePath = null;
        await Shell.Current.ClosePopupAsync(CancellationToken.None);
    }
}