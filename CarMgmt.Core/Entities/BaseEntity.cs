﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMgmt.Core.Entities
{
	public abstract class BaseEntity
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public DateTime CreatedDate { get; set; }

		public DateTime ModifiedDate { get; set; }
	}
}
