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
    private void RecognitionRRR_Clicked(object sender, EventArgs e)
    {
        LoadView(new RecognitionRRRView());
    }
    private void RecognitionInspecDevice_Clicked(object sender, EventArgs e)
    {
        LoadView(new RecognitionInspecDeviceView());
    }
    private void CertificateFlawDec_Clicked(object sender, EventArgs e)
    {
        LoadView(new CertificateFlawDecView());
    }
    private void VesselGeneral_Clicked(object sender, EventArgs e)
    {
        LoadView(new VesselGeneralView());
    }
    private void MeetProtocol_Clicked(object sender, EventArgs e)
    {
        LoadView(new MeetProtocolView());
    }
    private void OpenForm_Clicked(object sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            
        }
    }
}