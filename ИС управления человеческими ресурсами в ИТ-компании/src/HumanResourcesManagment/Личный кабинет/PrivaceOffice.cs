namespace HumanResourcesManagment
{
    public class PrivaceOffice : IPrivaceOffice
    {
        private ManagerPrivacyOffice manager;
        private AdminPrivaceOffice admin;

        public bool Authorization(string login, string password)
        {
            throw new System.NotImplementedException();
        }

        public bool Identification()
        {
            throw new System.NotImplementedException();
        }

        public void ControlPrivateOffice()
        {
            throw new System.NotImplementedException();
        }
    }
}