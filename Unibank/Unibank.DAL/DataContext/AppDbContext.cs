using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Unibank.DAL.Entities;

namespace Unibank.DAL.DataContext
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<DigitalBanking> DigitalBankings { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Tarif> Tarifs { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Credit> Credits { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<HRPageLink> HRPageLinks { get; set; }
        public DbSet<BannerVideo> BannerVideos { get; set; }
        public DbSet<HRPageBox> HRPageBoxes { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<BankAdvantage> BankAdvantages { get; set; }
        public DbSet<MainValue> MainValues { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Terminal> Terminals { get; set; }
        public DbSet<UTM> UTMs { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<SectionBranch> SectionBranches { get; set; }
        public DbSet<BranchBanner> BranchBanners { get; set; }
        public DbSet<CashbackPreview> CashbackPreviews { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<CashbackInfoBox> CashbackInfoBoxes { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<UCardBanner> UCardBanners { get; set; }
        public DbSet<UCardBannerOption> UCardBannerOptions { get; set; }
        public DbSet<TopInfoBox> TopInfoBoxes { get; set; }
        public DbSet<BottomInfoBox> BottomInfoBoxes { get; set; }
        public DbSet<UnibankMainValue> UnibankMainValues { get; set; }
        public DbSet<AboutBanner> AboutBanners { get; set; }
        public DbSet<AboutPageBox> AboutPageBoxes { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<ContactCordinate> ContactCordinates { get; set; }
        public DbSet<BriefInfo> BriefInfos { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<Method> Methods { get; set; }
        public DbSet<TransferMethod> TransferMethods { get; set; }
        public DbSet<TransferBanner> TransferBanners { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<CrossBox> CrossBoxes { get; set; }
        public DbSet<ConnectionBanner> ConnectionBanners { get; set; }
        public DbSet<UCardIndex> UCardIndexs { get; set; }
        public DbSet<UCardTab> UCardTabs { get; set; }
        public DbSet<UBank> UBanks { get; set; }
        public DbSet<UBankImage> UBankImages { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ExchangeCurrency> ExchangeCurrencies { get; set; }
        public DbSet<FirstCurrencyBox> FirstCurrencyBoxes { get; set; }
        public DbSet<SecondCurrencyBox> SecondCurrencyBoxes { get; set; }
        public DbSet<Filter> Filters { get; set; }
        public DbSet<FooterIcon> FooterIcons { get; set; }
        public DbSet<FooterLeftEnd> FooterLeftEnds { get; set; }
        public DbSet<FooterRightEnd> FooterRightEnds { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<FooterNavigation> FooterNavigations { get; set; }
        public DbSet<FooterNavigationExtention> FooterNavigationExtentions { get; set; }
        public DbSet<Header> Headers { get; set; }
        public DbSet<HeaderNavigation> HeaderNavigations { get; set; }
        public DbSet<Darkmode> Darkmodes { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Menu> Menus { get; set; }
    }
}
