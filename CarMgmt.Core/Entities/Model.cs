namespace CarMgmt.Core
{
	public class Model : BaseEntity
	{
		public int ModelId { get; set; }

		public virtual Brand? Brand { get; set; }
	}
}
