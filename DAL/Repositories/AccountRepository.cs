using KonobApp.Model.Models;
using KonobApp.Model.Repositories;
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
        public void CreateDatabase()
        {
            // nisam siguran ako ovo uopce treba, pa ako vidis da ne mi samo javi da izmjenim na svojem djelu. Cottiero
        }

        public WaiterModel CheckCredentials(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
