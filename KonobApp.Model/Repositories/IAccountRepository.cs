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
        void AddUser(string name, string surname, string email, string cardNumber, string password, DateTime dateOfBirth, bool isAdmin);
        void AddWaiter(string name, string surname, string username, string password, int caffeID);
        void DeleteUser(int id);
        void UpdateUser(int id, string name, string surname, string email, string cardNumber, string password, DateTime dateOfBirth, bool isAdmin);
        void UpdateWaiter(int id, string name, string surname, string username, string password, int caffeID);

        UserModel FindUserByID(int ID);
        WaiterModel FindWaiterByID(int ID);
        
    }
}
