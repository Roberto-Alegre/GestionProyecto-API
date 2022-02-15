using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityUser : EntityBase
    {
		public int id_usuario { get; set; }
		public string id_documento { get; set; }
		public string apellidos { get; set; }
		public string nombres { get; set;}
		public string direccion { get; set;}
		public string anexo { get; set;}
		public string celular_1 { get; set;}
		public string celular_2 { get; set;}
		public string email { get; set;}
		public string email_personal { get; set;}
		public string area { get; set;}
		public string puesto { get; set;}
		public string login { get; set;}
		public string password { get; set;}
	}
}
