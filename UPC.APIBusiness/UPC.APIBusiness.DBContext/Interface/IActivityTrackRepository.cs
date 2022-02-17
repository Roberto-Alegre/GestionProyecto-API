using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface IActivityTrackRepository
    {
        EntityBaseResponse GetListActivityTrack(int id);
        EntityBaseResponse GetActivityTrack(int id);
        EntityBaseResponse InsertActivityTrack(EntityActivityTrack activitytrack);
        EntityBaseResponse UpdateActivityTrack(EntityActivityTrack activitytrack);
    }
}
