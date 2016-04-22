namespace HumanResourcesManagment
{
    public interface IDeveloperWorkload
    {
        void Show();
        void Add(Developer developer);
        void Update(Developer developer);
        void Delete(Developer developer);
        void Search(Developer developer);
        void Search(string skills);
    }
}