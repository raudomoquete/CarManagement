using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMgmt.Core.Entities
{
	public class Model : BaseEntity
	{
		public virtual Brand? Brand { get; set; }
	}
}
