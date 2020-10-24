using KioskWebWizard.Context;
using KioskWebWizard.Models;
using KioskWebWizard.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KioskWebWizard.Services
{
    public class KioskService : IKioskService
    {
        private readonly KioskWebWizardContext _context;
        public bool Create(KioskModel kiosk)
        {
            _context.Kiosks.Add(kiosk);
            return _context.SaveChanges() > 0;        
        }

        public KioskModel Get(int id)
        {
            return _context.Kiosks.SingleOrDefault(g => g.ID == id);
        }
        public IList<KioskModel> GetAll()
        {
            return _context.Kiosks.ToList();
        }
        public int GetNumberOfKiosks(string userName)
        {
            return _context.Kiosks.Where(x => x.IdentityUser.UserName == userName).Count();
        }
        public bool Update(KioskModel kiosk)
        {
            _context.Kiosks.Update(kiosk);
            return _context.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var kioskToBeDeleted = _context.Kiosks.SingleOrDefault(d => d.ID == id);
            if (kioskToBeDeleted == null) return false;
            _context.Kiosks.Remove(kioskToBeDeleted);
            return _context.SaveChanges() > 0;
        }

    }
}
