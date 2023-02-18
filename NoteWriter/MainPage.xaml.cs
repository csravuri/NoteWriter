namespace NoteWriter;

public partial class MainPage : ContentPage
{
	readonly NotesList noteList;
	public MainPage()
	{
		InitializeComponent();
		noteList = NotesList.Load();
		BindingContext = noteList;
	}

	private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
	{
		var listView = sender as ListView;
		if (listView is null)
		{
			return;
		}

		await Navigation.PushAsync(new NotePage(noteList, e.Item as Note));
		listView.SelectedItem = null;
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new NotePage(noteList));
	}
}

