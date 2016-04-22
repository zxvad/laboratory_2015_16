using System;
using System.Collections.Generic;

namespace HumanResourcesManagment
{
    public class WorkTable: IWorkLoadTable
    {
        private Dictionary<Developer, Project> developersDictionary;
        private Dictionary<Manager, List<Project>> managerDictionary;
          
        public Delegate Show()
        {
            throw new System.NotImplementedException();
        }

        public void RelationshipDvlpr(Project project, Developer developer)
        {
            throw new System.NotImplementedException();
        }

        public void RelationshipMngr(Project project, Manager developer)
        {
            throw new System.NotImplementedException();
        }
    }
}