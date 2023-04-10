namespace CarMgmt.Core
{
	public class Brand : BaseEntity
	{

		public int BrandId { get; set; }


		public virtual ICollection<Model>? Models { get; set; }


		public virtual Vehicle? Vehicle { get; set; }
	}
}
