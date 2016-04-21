using EventoBackend.Entities;

namespace EventoBackend.Interfaces
{
    public interface IUserManager
    {
        bool NewUserRegistration(UserModel model);
        User FindById(long id);
        bool LogOn();
    }
}