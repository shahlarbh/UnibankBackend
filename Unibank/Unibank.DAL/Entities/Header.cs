namespace Unibank.DAL.Entities
{
    public class Header : TimeStample
    {
        public string Logo { get; set; }
        public string LogoUrl { get; set; }
        public string Connection { get; set; }
        public ICollection<HeaderNavigation> HeaderNavigations { get; set; }
        public ICollection<Language> Languages { get; set; }
        public ICollection<Menu> Menus { get; set; }
        public ICollection<Darkmode> Darkmodes { get; set; }
    }
}
