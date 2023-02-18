namespace DataSource
{
	public class NotesContent
	{
		public static string Read()
		{
			if (!File.Exists(NotesFile))
			{
				return null;
			}
			return File.ReadAllText(NotesFile);
		}

		public static void Write(string content)
		{
			File.WriteAllText(NotesFile, content);
		}

		const string NotesFile = "NotesFile.json";
	}
}
