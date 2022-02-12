using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;
 
namespace DBContext
{
    public interface IProjectRepository
    {
        EntityBaseResponse GetProject(int id);
        EntityBaseResponse GetListProjects();
        EntityBaseResponse InsertProject(EntityProject project);
        EntityBaseResponse UpdateProject(EntityProject project);
    }
}
