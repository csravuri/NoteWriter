using DataSource;

namespace NoteWriter;

public partial class NotePage : ContentPage
{
	readonly DataSource.NotesList nodeList;
	public NotePage(NotesList nodeList) : this()
	{
		this.nodeList = nodeList;
	}

	public NotePage()
	{
		InitializeComponent();
	}
}