using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityProject : EntityBase
    {
        public int id_proyecto { get; set; }
        public string nombre_proyecto { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_termino { get; set; }
        public string descripcion_proyecto { get; set; }

    }
}
