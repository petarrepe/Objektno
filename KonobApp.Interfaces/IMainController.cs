using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KonobApp.Interfaces
{
    public interface IMainController
    {
        void CreateDatabase();
        void LoadAll();
        void Login();
        bool CheckCredentials(Form form, string username, string password);


    }
}
