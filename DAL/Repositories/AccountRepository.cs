using KonobApp.Model.Models;
using KonobApp.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// Eager approach when constructing repository.
        /// This will automatically load all neccessary data from database.
        /// FIXME!!
        /// </summary>
        private AccountRepository()
        {
            LoadUsers();
            LoadWaiters();
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
            foreach (var waiter in _waiters)
            {
                if (waiter.Username == username && waiter.Password == password)
                {
                    return waiter;
                }
            }

            return null;
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

        public void AddWaiter(string name, string surname, string username, string password, int caffeID)
        {
            WaiterModel waiter = new WaiterModel();

            waiter.Name = name;
            waiter.Surname = surname;
            waiter.Username = username;
            waiter.Password = password;
            waiter.IDCaffe = caffeID;

            using (Facade facade = new Facade())
            {
                facade.Insert(waiter);
            }

            _waiters.Add(waiter);
        }

        public void AddUser(string name, string surname, string email, string cardNumber, string password, DateTime dateOfBirth, bool isAdmin)
        {
            UserModel user = new UserModel();

            user.Name = name;
            user.Surname = surname;
            user.Email = email;
            user.CardNumber = cardNumber;
            user.Password = password;
            user.DateOfBirth = dateOfBirth;
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

        public void UpdateUser(int id, string name, string surname, string email, string cardNumber, string password, DateTime dateOfBirth, bool isAdmin)
        {
            var user = _users.Where(t => t.IDUser == id).FirstOrDefault();

            user.Name = name;
            user.Surname = surname;
            user.Email = email;
            user.Password = password;
            user.DateOfBirth = dateOfBirth;
            user.IsAdmin = isAdmin;

            using (Facade facade = new Facade())
            {
                facade.Update(user);
            }

            _users.Remove(user);
            _users.Add(user);
        }

        public void UpdateWaiter(int id, string name, string surname, string username, string password, int caffeID)
        {
            var waiter = _waiters.Where(t => t.IDWaiter == id).FirstOrDefault();

            waiter.Name = name;
            waiter.Surname = surname;
            waiter.Username = username;
            waiter.Password = password;
            waiter.IDCaffe = caffeID;

            using (Facade facade = new Facade())
            {
                facade.Update(waiter);
            }

            _waiters.Remove(waiter);
            _waiters.Add(waiter);
        }

        public UserModel FindUserByID(int ID)
        {
            return _users.Where(u => u.IDUser == ID).First();
        }

        public WaiterModel FindWaiterByID(int ID)
        {
            return _waiters.Where(w => w.IDWaiter == ID).First();
        }
    }
}
