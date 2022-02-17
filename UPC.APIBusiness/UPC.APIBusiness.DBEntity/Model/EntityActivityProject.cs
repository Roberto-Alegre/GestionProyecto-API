using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityActivityProject : EntityBase
    {
        public int id_actividad_proyecto { get; set; }
        public int id_proyecto { get; set; }
        public int id_actividad { get; set; }
        public string actividad { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_termino { get; set; }

    }
}
