using System.Collections.ObjectModel;
using System.Text.Json;

namespace NoteWriter
{
	public class NotesList : ObservableCollection<Note>
	{
		NotesList() : base()
		{
		}

		public static NotesList Load()
		{
			var notesList = new NotesList();
			var jsonString = NotesContent.Read();

			if (string.IsNullOrEmpty(jsonString))
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

		private void AddRange(Note[] notes)
		{
			foreach (var note in notes)
			{
				Add(note);
			}
		}

		public void Save()
		{
			var notes = this.ToArray();
			var jsonString = JsonSerializer.Serialize(notes);
			NotesContent.Write(jsonString);
		}
	}
}