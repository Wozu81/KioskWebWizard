using KioskWebWizard.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KioskWebWizard.Services.Interfaces
{
    public interface IKioskService
    {
        bool Create(KioskModel kiosk);
        bool Create1(KioskLoyaltyTemplateDataModel kiosk);
        bool Create2(KioskMapTemplateDataModel kiosk);
        KioskModel Get(int id);
        IList<KioskModel> GetAll();
        int GetNumberOfKiosks(string userName);
        bool Update(KioskModel kiosk);
        bool Delete(int id);
        SelectList GetKioskTemplateList();
        bool CreateTemplate(KioskTemplatesModel kioskTemplates);
        IList<KioskTemplatesModel> GetAllTemplates();
        IList<KioskModel> GetAllByLoggedUser(string userName);
        int CheckForTemplateID(int kioskID);
        string GetTemplateNameByID(int KioskID);
        string GetLoyaltyNameByID(int KioskID);
        string GetLoyaltyDescriptionByID(int KioskID);
        string GetLoyaltyCarouselData1ByID(int KioskID);
        string GetLoyaltyCarouselData2ByID(int KioskID);
        string GetLoyaltyCarouselData3ByID(int KioskID);
        string GetLoyaltyCarouselData4ByID(int KioskID);
        string GetLoyaltyCarouselData5ByID(int KioskID);
        string GetMapNameByID(int KioskID);
        bool CreateUser(LoyaltyUsersModel loyaltyUsersModel);
        bool UpdateUser(LoyaltyUsersModel loyaltyUsers);

    }
}
