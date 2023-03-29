namespace CarMgmt.Core
{
	public class Model : BaseEntity
	{
		public int BrandId { get; set; }

		public virtual Brand? Brand { get; set; }
	}
}
