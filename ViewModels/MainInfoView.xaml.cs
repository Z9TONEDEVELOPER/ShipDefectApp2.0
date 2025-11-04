namespace MauiApp1;

public partial class MainInfoView : ContentPage
{
	public MainInfoView()
	{
		InitializeComponent();
		ShipIceBeltMMPicker.IsEnabled = false;
	}
	private void ShipIceBelt_CheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		if (e.Value) // чекбокс включен
        {
            ShipIceBeltMMPicker.IsEnabled = true;
        }
        else // выключен
        {
            ShipIceBeltMMPicker.IsEnabled = false;
            ShipIceBeltMMPicker.SelectedIndex = 0; // сбрасываем на None
        }
	}
}