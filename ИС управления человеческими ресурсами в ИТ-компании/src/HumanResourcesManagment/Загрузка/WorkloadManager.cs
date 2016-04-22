using System;

namespace HumanResourcesManagment
{
    public class WorkloadManager : IWorkloadManager
    {
        private Project project;
        private DeveloperWorkLoad developer;
        private ManagerWorkload manager;
        private WorkTable workTable;

        public void Event()
        {
            throw new NotImplementedException();
        }
    }
}