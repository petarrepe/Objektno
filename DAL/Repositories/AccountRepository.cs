using KonobApp.Model.Models;
using KonobApp.Model.Repositories;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private static AccountRepository _instance = null;

        private IList<WaiterModel> _waiters = new List<WaiterModel>();
        private IList<UserModel> _users = new List<UserModel>();

        public IList<UserModel> Users
        {
            get
            {
                return _users;
            }
        }

        public IList<WaiterModel> Waiters
        {
            get
            {
                return _waiters;
            }
        }

        private AccountRepository()
        {
        }

        public static AccountRepository GetInstance()
        {
            if(_instance == null)
            {
                _instance = new AccountRepository();
            }
            return _instance;
        }

        public WaiterModel CheckCredentials(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void LoadUsers()
        {
            using (Facade facade = new Facade())
            {
                _users = facade.FetchAll<UserModel>();
            }
        }

        public void LoadWaiters()
        {
            using (Facade facade = new Facade())
            {
                _waiters = facade.FetchAll<WaiterModel>();
            }
        }

        public void AddWaiter(string name, string username, string surname, string password)
        {
            WaiterModel waiter = new WaiterModel();

            waiter.Name = name;
            waiter.Surname = surname;
            waiter.Username = username;
            waiter.Password = password;

            using (Facade facade = new Facade())
            {
                facade.Insert(waiter);
            }

            _waiters.Add(waiter);
        }

        public void AddUser(string name, string surname, string email, string cardNumber, string password, bool isAdmin)
        {
            UserModel user = new UserModel();

            user.Name = name;
            user.Surname = surname;
            user.Email = email;
            user.CardNumber = cardNumber;
            user.Password = password;
            user.IsAdmin = isAdmin;

            using (Facade facade = new Facade())
            {
                facade.Insert(user);
            }

            _users.Add(user);
        }

        public void DeleteWaiter(int id)
        {
            var waiter = _waiters.Where(t => t.IDWaiter == id).First();

            _waiters.Remove(waiter);

            using (Facade facade = new Facade())
            {
                facade.Delete(waiter);
            }

        }

        public void DeleteUser(int id)
        {
            var user = _users.Where(t => t.IDUser == id).First();

            _users.Remove(user);

            using (Facade facade = new Facade())
            {
                facade.Delete(user);
            }
        }

        public void UpdateUser(int id, string name, string surname, string email, string cardNumber, string password, bool isAdmin)
        {
            var user = _users.Where(t => t.IDUser == id).FirstOrDefault();

            user.Name = name;
            user.Surname = surname;
            user.Email = email;
            user.Password = password;
            user.IsAdmin = isAdmin;

            using (Facade facade = new Facade())
            {
                facade.Update(user);
            }

            _users.Remove(user);
            _users.Add(user);
        }

        public void UpdateWaiter(int id, string name, string surname, string username, string password)
        {
            var waiter = _waiters.Where(t => t.IDWaiter == id).FirstOrDefault();

            waiter.Name = name;
            waiter.Surname = surname;
            waiter.Username = username;
            waiter.Password = password;

            using (Facade facade = new Facade())
            {
                facade.Update(waiter);
            }

            _waiters.Remove(waiter);
            _waiters.Add(waiter);
        }
    }
}
