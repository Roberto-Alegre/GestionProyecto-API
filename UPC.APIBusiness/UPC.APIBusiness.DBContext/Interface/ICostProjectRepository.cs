using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface ICostProjectRepository
    {
        EntityBaseResponse GetListCostProject(int id);
        EntityBaseResponse GetCostProject(int id);
        EntityBaseResponse InsertCostProject(EntityCostProject costproject);
        EntityBaseResponse UpdateCostProject(EntityCostProject costproject);

    }
}
