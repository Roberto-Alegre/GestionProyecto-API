using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface IActivityProjectRepository
    {
        EntityBaseResponse GetListActivityProject(int id);
        EntityBaseResponse GetActivityProject(int id);
        EntityBaseResponse InsertActivityProject(EntityActivityProject activityproject);
        EntityBaseResponse UpdateActivityProject(EntityActivityProject activityproject);
    }
}
