using EventoBackend.DB.Implementation;
using EventoBackend.Entities;
using EventoBackend.Identity.Interfaces;
using EventoBackend.Models;

namespace EventoBackend.Identity.Implementation
{
    public class Identity : IIdentity
    {
        private UserStorage _userStorage;

        public Identity(UserStorage userStorage)
        {
            this._userStorage = userStorage;
        }

        public bool AddNewUser(RegistrationModel model)
        {
            var user = new User() {Name = model.Name};
            _userStorage.Save(user);
            return true;
        }

        public bool Authentication(string email, string password)
        {
            throw new System.NotImplementedException();
        }
        
    }
}