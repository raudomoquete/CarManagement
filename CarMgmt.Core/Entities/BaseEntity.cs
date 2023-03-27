namespace CarMgmt.Core
{
	public abstract class BaseEntity
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public DateTime CreatedDate { get; set; }

		public DateTime ModifiedDate { get; set; }
	}
}
