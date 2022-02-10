using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
	public class EntityStatistics : EntityBase
	{
		public int id_indicadores { get; set;}   
		public int id_proyecto { get; set; }
		public decimal monto_presupuestado { get; set; }
		public decimal porcentaje_planificado { get; set; }
		public decimal porcentaje_ejecutado { get; set; }
		public string estado_proyecto { get; set; }
	}
}
