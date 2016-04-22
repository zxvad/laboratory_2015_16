using System.Collections.Generic;

namespace HumanResourcesManagment
{
    public interface IManagerPrivacyOffice
    {
        void ShowPrivacyOffice();
        void AllListProject(List<Project> projects);
        void ShowProject(Project project);
        void SetRequest(Request request);
        void ShowMyRequests(List<Request> myRequests);
    }
}