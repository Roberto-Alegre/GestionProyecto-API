using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityLoginResponse
    {
		public int id_usuario { get; set; }
		public string id_documento { get; set; }
		public string apellidos { get; set; }
		public string nombres { get; set; }
		public string email { get; set; }
		public string area { get; set; }
		public string puesto { get; set; }
		public string token { get; set; }
	}
}
