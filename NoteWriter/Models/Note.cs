using System.Collections.ObjectModel;

namespace NoteWriter
{
	public class Note
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public ObservableCollection<string> ImagePaths { get; set; } = new ObservableCollection<string>();
	}
}
