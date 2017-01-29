using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonobApp.Interfaces
{
    public interface INotificationController
    {
        bool IsStarted { get; }
        void StartListening();
        void StopListening();
    }
}
