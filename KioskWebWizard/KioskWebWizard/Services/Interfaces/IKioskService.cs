using KioskWebWizard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KioskWebWizard.Services.Interfaces
{
    public interface IKioskService
    {
        bool Create(KioskModel kiosk);
        KioskModel Get(int id);
        IList<KioskModel> GetAll();
        public int GetNumberOfKiosks(string userName);
        bool Update(KioskModel kiosk);
        bool Delete(int id);
    }
}
