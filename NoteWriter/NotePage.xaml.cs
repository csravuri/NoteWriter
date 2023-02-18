using DataSource;

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

	private void SaveButton_Clicked(object sender, EventArgs e)
	{
		if (!nodeList.Exists(x => x.Id == note.Id))
		{
			nodeList.Add(note);
		}
		nodeList.Save();
	}
}