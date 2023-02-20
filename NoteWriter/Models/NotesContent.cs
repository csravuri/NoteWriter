namespace NoteWriter
{
	public class NotesContent
	{
		public static string Read()
		{
			var notesFileFullPath = NotesFileFullPath;
			if (!File.Exists(notesFileFullPath))
			{
				return null;
			}
			return File.ReadAllText(notesFileFullPath);
		}

		public static void Write(string content)
		{
			File.WriteAllText(NotesFileFullPath, content);
		}

		const string NotesFile = "NotesFile.json";
		static string NotesFileFullPath => Path.Combine(FileSystem.Current.AppDataDirectory, NotesFile);
	}
}
