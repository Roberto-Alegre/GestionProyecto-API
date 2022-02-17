using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityCostProject: EntityBase
    {
        public int id_costo_proyecto { get; set; }
        public int id_proyecto { get; set; }
        public string id_costo { get; set; }
        public string concepto { get; set; }
        public string moneda { get; set; }
        public decimal monto { get; set; }
    }
}
