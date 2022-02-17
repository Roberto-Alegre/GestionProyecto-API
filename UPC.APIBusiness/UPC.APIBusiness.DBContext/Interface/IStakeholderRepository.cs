using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;


namespace DBContext
{
    public interface IStakeholderRepository
    {
        EntityBaseResponse GetListStakeholder(int id_proyecto);
        EntityBaseResponse GetListUsuarios();
        EntityBaseResponse InsertStakeholder(EntityStakeholder stakeholder);

    }
}
