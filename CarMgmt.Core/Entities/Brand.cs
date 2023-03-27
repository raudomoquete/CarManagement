using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMgmt.Core.Entities
{
	public class Brand : BaseEntity
	{
		public virtual ICollection<Model>? Models { get; set; }

		public virtual Vehicle? Vehicle { get; set; }
	}
}
