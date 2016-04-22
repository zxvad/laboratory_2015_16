using System;

namespace HumanResourcesManagment
{
    public interface IWorkLoadTable
    {
        Delegate Show();
        void RelationshipDvlpr(Project project, Developer developer);
        void RelationshipMngr(Project project, Manager developer);
    }
}