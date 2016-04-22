using EventoBackend.Models;

namespace EventoBackend.Identity.Interfaces
{
    public interface IIdentity
    {
        bool AddNewUser(RegistrationModel model);
        bool Authentication(string email, string password);
        bool PasswordReset(string email);
    }
}