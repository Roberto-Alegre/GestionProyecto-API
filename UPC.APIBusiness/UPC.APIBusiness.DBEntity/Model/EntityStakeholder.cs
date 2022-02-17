using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBEntity
{
    public class EntityStakeholder : EntityBase
    {
		public int id_interesados_proyecto { get; set; }
		public int id_proyecto { get; set; }
		public int id_usuario { get; set; }
		public string nombres { get; set; }
		public string apellidos { get; set; }
		public string tipo { get; set; }
		public string area { get; set; }

	}
}
