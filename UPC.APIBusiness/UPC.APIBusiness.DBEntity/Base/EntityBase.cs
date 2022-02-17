using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityBase
    {
        //public bool Activo { get; set; }
        public int auditoria_usuario_ingreso { get; set; }
        public DateTime auditoria_fecha_ingreso { get; set; }
        public int auditoria_usuario_modificacion { get; set; }
        public DateTime auditoria_fecha_modificacion { get; set; }
    }
}
