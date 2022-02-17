using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface ICostRepository
    {
        EntityBaseResponse GetCost(int id);
        EntityBaseResponse GetListCost();
        EntityBaseResponse InsertCost(EntityCost cost);
        EntityBaseResponse UpdateCost(EntityCost cost);
    }
}
