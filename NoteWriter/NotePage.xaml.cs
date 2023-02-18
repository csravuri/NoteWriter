namespace NoteWriter;

public partial class NotePage : ContentPage
{
	readonly NotesList nodeList;
	readonly Note note;

	public NotePage(NotesList nodeList, Note note = null) : this()
	{
		this.nodeList = nodeList;
		this.note = note ?? new Note();
		BindingContext = this.note;
	}

	public NotePage()
	{
		InitializeComponent();
	}

	private async void SaveButton_Clicked(object sender, EventArgs e)
	{
		if (!nodeList.Contains(note, new NoteEqualityComparer()))
		{
			nodeList.Add(note);
		}
		nodeList.Save();

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
}