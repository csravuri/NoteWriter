namespace NoteWriter;

public partial class NotePage : ContentPage
{
	readonly NotesList noteList;
	readonly Note note;

	public NotePage(NotesList nodeList, Note note = null) : this()
	{
		this.noteList = nodeList;
		this.note = note ?? new Note();
		BindingContext = this.note;
	}

	public NotePage()
	{
		InitializeComponent();
	}

	private async void SaveButton_Clicked(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(note.Name))
		{
			await DisplayAlert("Error", "Enter Name!", "Ok");
			return;
		}

		if (noteList.Contains(note, new NoteEqualityComparer()))
		{
			int index = noteList.IndexOf(note);
			noteList.Remove(note);
			noteList.Insert(index, note);
		}
		else
		{
			noteList.Add(note);
		}
		noteList.Save();

		await Navigation.PopAsync();
	}

	class NoteEqualityComparer : IEqualityComparer<Note>
	{
		bool IEqualityComparer<Note>.Equals(Note x, Note y)
		{
			return x.Id == y.Id;
		}

		int IEqualityComparer<Note>.GetHashCode(Note obj)
		{
			return obj.GetHashCode();
		}
	}

	private async void CancelButton_Clicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}

	private async void GalaryButton_Clicked(object sender, EventArgs e)
	{
		var fileResult = await MediaPicker.PickPhotoAsync();
		if (fileResult != null)
		{
			var localPath = Path.Combine(FileSystem.Current.AppDataDirectory, fileResult.FileName);
			File.Copy(fileResult.FullPath, localPath, true);
			note.ImagePaths.Add(localPath);
		}
	}

	private async void CameraButton_Clicked(object sender, EventArgs e)
	{
		var options = new MediaPickerOptions();
		options.Title = "Take a Photo";
		var fileResult = await MediaPicker.CapturePhotoAsync(options);
		if (fileResult != null)
		{
			var localPath = Path.Combine(FileSystem.Current.AppDataDirectory, fileResult.FileName);
			File.Move(fileResult.FullPath, localPath, true);
			note.ImagePaths.Add(localPath);
		}

	}

	private void DeleteButton_Clicked(object sender, EventArgs e)
	{
		var deleteButton = sender as Button;
		if (deleteButton != null)
		{
			var selectedImage = deleteButton.CommandParameter as string;
			if (!string.IsNullOrEmpty(selectedImage))
			{
				note.ImagePaths.Remove(selectedImage);
				File.Delete(selectedImage);
			}
		}
	}
}