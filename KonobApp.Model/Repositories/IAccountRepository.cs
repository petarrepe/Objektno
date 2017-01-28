using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonobApp.Model.Models;

namespace KonobApp.Model.Repositories
{
    public interface IAccountRepository
    {
        IList<UserModel> Users { get; }
        IList<WaiterModel> Waiters { get; }
        void LoadUsers();
        void LoadWaiters();
        void AddUser(string name, string surname, string email, string cardNumber, string password, bool isAdmin);
        void DeleteUser(int id);
        void UpdateUser(int id, string name, string surname, string email, string cardNumber, string password, bool isAdmin);
        
    }
}
