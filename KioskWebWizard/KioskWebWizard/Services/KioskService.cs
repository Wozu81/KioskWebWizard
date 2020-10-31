using KioskWebWizard.Context;
using KioskWebWizard.Models;
using KioskWebWizard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        public bool Create1(KioskLoyaltyTemplateDataModel kiosk)
        {
            _context.KioskLoyaltyTemplateDatas.Add(kiosk);
            return _context.SaveChanges() > 0;
        }

        public bool Create2(KioskMapTemplateDataModel kiosk)
        {
            _context.KioskMapTemplateDatas.Add(kiosk);
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
            var a = _context.Kiosks.Where(a => a.UserId == userName).Count();
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
            var a = new SelectList(_context.KioskTemplates, "ID", "TemplateName");
            return a;
        }

        public bool CreateTemplate(KioskTemplatesModel kioskTemplates)
        {
            _context.KioskTemplates.Add(kioskTemplates);
            return _context.SaveChanges() > 0;
        }

        public IList<KioskTemplatesModel> GetAllTemplates()
        {
            return _context.KioskTemplates.ToList();
        }

        public IList<KioskModel> GetAllByLoggedUser(string userName)
        {
            return _context.Kiosks.Where(x => x.IdentityUser.UserName == userName).ToList();
        }

        public int CheckForTemplateID(int kioskID)
        {
            var a = _context.Kiosks.Where(i => i.ID == kioskID).
                Include(t => t.KioskTemplate).
                Select(a => a.KioskTemplate.ID).
                FirstOrDefault();

            return a;
        }

        public string GetLoyaltyNameByID(int KioskID)
        {
            var a = _context.Kiosks.Where(i => i.ID == KioskID).
                Include(t => t.KioskLoyaltyTemplateData).
                Select(s => s.KioskLoyaltyTemplateData.LoyaltyName).
                FirstOrDefault();
            return a;
        }

        public string GetTemplateNameByID(int KioskID)
        {
            var a = _context.Kiosks.Where(i => i.ID == KioskID).
                Include(t => t.KioskTemplate).
                Select(s =>s.KioskTemplate.TemplateName).
                FirstOrDefault();
            return a;
        }

        public string GetLoyaltyDescriptionByID(int KioskID)
        {
            var a = _context.Kiosks.Where(i => i.ID == KioskID).
                Include(t => t.KioskLoyaltyTemplateData).
                Select(s => s.KioskLoyaltyTemplateData.LoyaltyDescription).
                FirstOrDefault();
            return a;
        }

        public string GetLoyaltyCarouselData1ByID(int KioskID)
        {
            var a = _context.Kiosks.Where(i => i.ID == KioskID).
                Include(t => t.KioskLoyaltyTemplateData).
                Select(s => s.KioskLoyaltyTemplateData.LoyaltyCarouselData1).
                FirstOrDefault();
            return a;
        }

        public string GetLoyaltyCarouselData2ByID(int KioskID)
        {
            var a = _context.Kiosks.Where(i => i.ID == KioskID).
                Include(t => t.KioskLoyaltyTemplateData).
                Select(s => s.KioskLoyaltyTemplateData.LoyaltyCarouselData2).
                FirstOrDefault();
            return a;
        }

        public string GetLoyaltyCarouselData3ByID(int KioskID)
        {
            var a = _context.Kiosks.Where(i => i.ID == KioskID).
                Include(t => t.KioskLoyaltyTemplateData).
                Select(s => s.KioskLoyaltyTemplateData.LoyaltyCarouselData3).
                FirstOrDefault();
            return a;
        }

        public string GetLoyaltyCarouselData4ByID(int KioskID)
        {
            var a = _context.Kiosks.Where(i => i.ID == KioskID).
                Include(t => t.KioskLoyaltyTemplateData).
                Select(s => s.KioskLoyaltyTemplateData.LoyaltyCarouselData4).
                FirstOrDefault();
            return a;
        }

        public string GetLoyaltyCarouselData5ByID(int KioskID)
        {
            var a = _context.Kiosks.Where(i => i.ID == KioskID).
                Include(t => t.KioskLoyaltyTemplateData).
                Select(s => s.KioskLoyaltyTemplateData.LoyaltyCarouselData5).
                FirstOrDefault();
            return a;
        }

        public string GetMapNameByID(int KioskID)
        {
            var a = _context.Kiosks.Where(i => i.ID == KioskID).
                Include(t => t.KioskMapTemplateData).
                Select(s => s.KioskMapTemplateData.MapName).
                FirstOrDefault();
            return a;
        }

        public bool CreateUser(LoyaltyUsersModel loyaltyUsersModel)
        {
            _context.LoyaltyUsers.Add(loyaltyUsersModel);
            return _context.SaveChanges() > 0;
        }
        public bool UpdateUser(LoyaltyUsersModel loyaltyUsers)
        {
            _context.LoyaltyUsers.Update(loyaltyUsers);
            return _context.SaveChanges() > 0;
        }
    }
}
