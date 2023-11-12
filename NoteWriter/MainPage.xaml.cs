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
		if (sender is ListView listView)
		{
			await Navigation.PushAsync(new NotePage(noteList, e.Item as Note));
			listView.SelectedItem = null;
		}
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new NotePage(noteList));
	}

	private async void DeleteButton_Clicked(object sender, EventArgs e)
	{
		if (sender is Button deleteButton
			&& deleteButton.CommandParameter is Note note
			&& await Shell.Current.DisplayAlert("Delete!", "Want to delete?", Yes, No))
		{
			foreach (var image in note.ImagePaths)
			{
				if (!string.IsNullOrEmpty(image) && File.Exists(image))
				{
					File.Delete(image);
				}
			}

			var notes = noteList.ToArray();

			noteList.Clear();
			foreach (var item in notes)
			{
				if (item.Id != note.Id)
				{
					noteList.Add(item);
				}
			}

			noteList.Save();
		}
	}

	const string Yes = "Yes";
	const string No = "No";
}

