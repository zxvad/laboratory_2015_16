using System;

namespace HumanResourcesManagment
{
    public interface IWorkloadManager
    {
        void Event (Delegate eventDelegate);         
    }
}