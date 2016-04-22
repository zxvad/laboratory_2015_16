namespace HumanResourcesManagment
{
    public interface IPrivaceOffice
    {
        bool Authorization(string login, string password);
        bool Identification();
        void ControlPrivateOffice();
    }
}