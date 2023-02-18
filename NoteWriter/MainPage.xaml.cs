namespace NoteWriter;

public partial class MainPage : ContentPage
{
	readonly NotesList nodeList;
	public MainPage()
	{
		InitializeComponent();
		nodeList = NotesList.Load();
		BindingContext = nodeList;
	}

	private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
	{
		var listView = sender as ListView;
		if (listView is null)
		{
			return;
		}

		await Navigation.PushAsync(new NotePage(nodeList, e.Item as Note));
		listView.SelectedItem = null;
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new NotePage(nodeList));
	}
}

