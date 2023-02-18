using System.Text.Json;

namespace DataSource
{
	public class NotesList : List<Note>
	{
		NotesList() : base()
		{
		}

		public static NotesList Load()
		{
			var notesList = new NotesList();
			var jsonString = NotesContent.Read();

			if (jsonString is null)
			{
				return notesList;
			}

			var notes = JsonSerializer.Deserialize<Note[]>(jsonString);
			if (notes != null)
			{
				notesList.AddRange(notes);
			}

			return notesList;
		}

		public void Save()
		{
			var notes = this.ToArray();
			var jsonString = JsonSerializer.Serialize(notes);
			NotesContent.Write(jsonString);
		}
	}
}