using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KioskWebWizard.Models;
using KioskWebWizard.ViewModel.Kiosk;

namespace KioskWebWizard.Context
{
    public class KioskWebWizardContext : IdentityDbContext
    {
        public KioskWebWizardContext(DbContextOptions<KioskWebWizardContext> options) : base(options)
        {
        }
        public DbSet<KioskModel> Kiosks { get; set; }
        public DbSet<KioskTemplatesModel> KioskTemplates { get; set; }
        //public DbSet<TemplateTypeModel> TemplateTypes { get; set; }
        public DbSet<KioskLoyaltyTemplateDataModel> KioskLoyaltyTemplateDatas { get; set; }
        public DbSet<KioskMapTemplateDataModel> KioskMapTemplateDatas { get; set; }
        public DbSet<LoyaltyUsersModel> LoyaltyUsers { get; set; }
    }
}
