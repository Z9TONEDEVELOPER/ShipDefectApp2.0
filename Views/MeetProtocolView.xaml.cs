namespace MauiApp1;

public partial class MeetProtocolView : ContentView
{
	public MeetProtocolView()
	{
		InitializeComponent();
	}
	private void LoadView(View view)
	{
		RightContent.Content = view;
	}	
	private void OpenPlan_Clicked(object sender, EventArgs e)
	{
		LoadView(new PlanView());
	}
	private void OpenMaterials_Clicked(object sender, EventArgs e)
	{
		LoadView(new MaterialsView());
	}
	private void OpenNorms_Clicked(object sender, EventArgs e)
	{
		LoadView(new NormsView());	
	}	
}