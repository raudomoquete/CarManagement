using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMgmt.Core.Entities
{
	public enum CarStatus
	{
		/// <summary>
		/// No Aplica, indica un Error: Algo en la logica no fue aplicado
		/// </summary>
		Na,

		/// <summary>
		/// Vehiculo Nuevo
		/// </summary>
		New,

		/// <summary>
		/// Vehiculo Usado
		/// </summary>
		Used,
	}

	public class Status : BaseEntity
	{
		public string EnumName { get; set; } = null!;

		public virtual Vehicle? Vehicle { get; set; }

	}
}
