using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityActivityTrack : EntityBase
    {
        public int id_seguimiento_actividad { get; set; }
        public int id_actividad_proyecto { get; set; }
        public string actividad { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_termino { get; set; }
        public DateTime fecha_inicio_real { get; set; }
        public DateTime fecha_termino_real { get; set; }
    }
}
