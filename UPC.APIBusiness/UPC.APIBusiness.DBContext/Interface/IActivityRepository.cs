using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface IActivityRepository
    {
        EntityBaseResponse GetActivity(int id);
        EntityBaseResponse GetListActivity();
        EntityBaseResponse InsertActivity(EntityActivity activity);
        EntityBaseResponse UpdateActivity(EntityActivity activity);

    }
}
