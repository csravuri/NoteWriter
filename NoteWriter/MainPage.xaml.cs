namespace NoteWriter;

public partial class MainPage : ContentPage
{
	readonly DataSource.NotesList nodeList;
	public MainPage()
	{
		InitializeComponent();
		nodeList = DataSource.NotesList.Load();
		BindingContext = nodeList;
	}

	private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
	{

	}

	private void Button_Clicked(object sender, EventArgs e)
	{

	}
}

