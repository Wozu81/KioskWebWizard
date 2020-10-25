using KioskWebWizard.Context;
using KioskWebWizard.Models;
using KioskWebWizard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KioskWebWizard.Services
{
    public class KioskService : IKioskService
    {
        private readonly KioskWebWizardContext _context;
        public KioskService(KioskWebWizardContext context)
        {
            _context = context;
        }

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
            var a = _context.Kiosks.Where(x => x.IdentityUser.UserName == userName).Count();
            return a;
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

        public SelectList GetKioskTemplateList()
        {
            return new SelectList(_context.KioskTemplates, "ID", "Name");
        }
    }
}
