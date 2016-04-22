namespace HumanResourcesManagment
{
    public interface IManagerWorkload
    {
        void Show();
        void Add(Manager manager);
        void Update(Manager manager);
        void Delete(Manager manager);
    }
}