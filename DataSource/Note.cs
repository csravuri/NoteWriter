namespace DataSource
{
	public class Note
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string[] ImagePaths { get; set; } = Array.Empty<string>();
	}
}
