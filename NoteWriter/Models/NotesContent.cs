namespace NoteWriter
{
	public class NotesContent
	{
		public static string Read()
		{
			if (!File.Exists(NotesFileFullPath))
			{
				return null;
			}
			return File.ReadAllText(NotesFileFullPath);
		}

		public static void Write(string content)
		{
			File.WriteAllText(NotesFileFullPath, content);
		}

		const string NotesFile = "NotesFile.json";
		static string NotesFileFullPath => FileSystem.Current.AppDataDirectory + NotesFile;
	}
}
